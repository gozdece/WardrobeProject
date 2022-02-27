using AutoMapper;
using Core.Dtos;
using Core.Dtos.UserDto;
using Core.Models;
using Core.Services;
using CryptoHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Mail;
using Service.RabbitMq;
using Service.Services;
using Service.Services.JwtToken;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly IService<User> _service;
        private readonly SignInManager<User> _signInManager;
        private readonly IMailSender _mailService;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public UserController(IMapper mapper,UserManager<User> userManager,SignInManager<User> signInManager,
            IService<User> service, IMailSender mailService, IJwtAuthenticationManager jwtAuthenticationManager) : base(mapper)
        {

            _userManager = userManager;
            _service = service;
            _signInManager = signInManager;
            _mailService = mailService;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
                if (ModelState.IsValid)
                {
                    var userModel = _mapper.Map<User>(userRegisterDto);
                    var result = await _userManager.CreateAsync(userModel, userRegisterDto.Password);
                    if(result.Succeeded)
                    {
                        await _signInManager.SignInAsync(userModel, false);

                        Producer producer = new();
                        producer.SendEmail(new EmailModel { Email = userModel.Email, Subject = "Güvenlik kontrolü", Message = "Welcome to Wardrobe !" });

                    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
                    }
                }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Kayit yaparken sorun oldu"));

        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            var identityResult = await _signInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);
            Producer producer = new();
            if (user is null || !identityResult.Succeeded)
            {
                await _userManager.AccessFailedAsync(user); //Eğer ki başarısız bir account girişi söz konusu ise AccessFailedCount kolonundaki değer +1 arttırılacaktır.
                int failcount = await _userManager.GetAccessFailedCountAsync(user); //Kullanıcının yapmış olduğu başarısız giriş deneme adedini alıyoruz.
                if (failcount == 3)
                {
                    await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1))); //Eğer ki başarısız giriş denemesi 3'ü bulduysa ilgili kullanıcının hesabını kilitliyoruz.

                    
                    producer.SendEmail(new EmailModel { Email = userLoginDto.Email, Subject = "Güvenlik kontrolü", Message = "Art arda 3 basarisiz deneme.Hesabiniz bloke oldu." });
                    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Art arda 3 basarisiz deneme. Hesabiniz bloke oldu."));

                }
                else
                {
                    if (identityResult.IsLockedOut)
                    {
                        producer.SendEmail(new EmailModel { Email = userLoginDto.Email, Subject = "Güvenlik kontrolü", Message = "Art arda 3 basarisiz deneme.Hesabiniz bloke oldu." });
                        return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Art arda 3 başarısız deneme"));
                    }

                    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "E-posta veya şifre yanlış."));
                }
            }
            else
            {
                await _userManager.ResetAccessFailedCountAsync(user);//Önceki hataları girişler neticesinde +1 arttırılmış tüm değerleri 0(sıfır)a çekiyoruz.

                var token = _jwtAuthenticationManager.Authenticate(user);

                return Ok(token);



            }
                
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Çıkış yapıldı");
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("sendemail")]
        public async Task<IActionResult> SendMail()
        {

            await _mailService.SendEmailAsync("gozdecengiiz98@gmail.com", "konu", "mesaj");
            return Ok();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(User user)
        {
            var token = _jwtAuthenticationManager.Authenticate(user);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

       
    }
}

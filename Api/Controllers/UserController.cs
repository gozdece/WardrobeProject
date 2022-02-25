using AutoMapper;
using Core.Dtos;
using Core.Dtos.UserDto;
using Core.Models;
using Core.Services;
using CryptoHelper;
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
        private readonly JwtAuthentication _jwtAuthentication;
        private readonly IService<User> _service;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenGenerator _tokenGenerator;
        private readonly IMailService _mailService;
        public UserController(IMapper mapper,UserManager<User> userManager,SignInManager<User> signInManager,
            TokenGenerator tokenGenerator, IService<User> service,IMailService mailService) : base(mapper)
        {
            _userManager = userManager;
            _service = service;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _mailService = mailService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
          
                if (ModelState.IsValid)
                {
                    var userModel = _mapper.Map<User>(userRegisterDto);
                    var result = await _userManager.CreateAsync(userModel, userRegisterDto.Password);
                    if(result.Succeeded)
                    {
                        await _signInManager.SignInAsync(userModel, false);

                    //hoşgeldin emaili gidecek

                        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
                    }
                }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Kayit yaparken sorun oldu"));

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user is null)
            {
                return BadRequest("Böyle bir kullanıcı yok");
            }
            else
            {
                if (ModelState.IsValid)
                {                                    
                    var identityResult = await _signInManager.PasswordSignInAsync(user,userLoginDto.Password,false,false);

                    if(identityResult.Succeeded)
                    {

                        await _userManager.ResetAccessFailedCountAsync(user);//Önceki hataları girişler neticesinde +1 arttırılmış tüm değerleri 0(sıfır)a çekiyoruz.
                        await _jwtAuthentication.AuthenticateAsync(user);
                       
                        Token token = _tokenGenerator.CreateToken(user);
                        Response.Headers.Add("Token", token.ToString());
                        
                        return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user); //Eğer ki başarısız bir account girişi söz konusu ise AccessFailedCount kolonundaki değer +1 arttırılacaktır.
                        int failcount = await _userManager.GetAccessFailedCountAsync(user); //Kullanıcının yapmış olduğu başarısız giriş deneme adedini alıyoruz.
                        if (failcount == 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1))); //Eğer ki başarısız giriş denemesi 3'ü bulduysa ilgili kullanıcının hesabını kilitliyoruz.
                            //ModelState.AddModelError("Locked", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dk kitlenmiştir.");
                            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Art arda 3 basarisiz deneme. Hesabiniz bloke oldu."));

                        }
                        else
                        {
                            if (identityResult.IsLockedOut)
                            {
                                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Art arda 3 başarısız deneme"));
                                
                            }
                            else
                            {
                                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "E-posta veya şifre yanlış."));
                            }
                                
                        }                        
                    }
                    
                }
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Hata olustu"));
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
            return Ok(_mailService.SendEmailAsync("gozdecengiiz98@gmail.com", "konu", "mesaj"));
        }

       
    }
}

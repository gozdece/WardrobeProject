using AutoMapper;
using Core.Dtos.OfferDto;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IOfferService _service;
        private readonly UserManager<User> _userManager;
        public OfferController(IMapper mapper,IProductService productService,IOfferService service,UserManager<User> userManager) : base(mapper)
        {
            _productService = productService;
            _service = service;
            _userManager = userManager;

        }

        /// <summary>
        /// Kullanıcı bir ürüne teklif verir
        /// </summary>
        /// <param name="postOfferDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GiveOffer(PostOfferDto postOfferDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            postOfferDto.UserId = currentUser.Id;

            var result = _productService.IsOfferableProduct(postOfferDto.ProductId);

            if(result)
            {
                
                if (_productService.CheckOfferForUser(currentUser, postOfferDto))
                {
                    return BadRequest("Bu urune daha once teklif verdiniz");
                }

                if(postOfferDto.OfferedPrice == 0 && postOfferDto.OfferedPricePercentage == 0)
                {
                    return BadRequest("Urune ya teklif verebilirsiniz ya da urun fiyati uzerinden yuzde bir teklif degeri verebilirsiniz. Ikisi ayni anda olmaz");
                }

                var offer = _mapper.Map<Offer>(postOfferDto);
                var productPrice = _productService.GetPriceForProduct(postOfferDto.ProductId);

                offer.OfferedPrice = _service.CalcOfferPrice(postOfferDto, productPrice);
                await _service.AddAsync(offer);
                return Ok();
            }
            else
            {
                return BadRequest("Bu ürüne teklif verilemiyor");
            }

            
        }

        /// <summary>
        /// Bütün offerlar listenir
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetOffer()
        {
            var offers = await _service.GetAllAsync();
            var offerDtos = _mapper.Map<List<OfferDto>>(offers.ToList());
            return Ok(offerDtos);
        }

        /// <summary>
        /// Kullanıcının belirli bir ürüne verdiği offer değeri
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet(("/product/{productId}"))]
        public async Task<IActionResult> GetOfferByUser(int productId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var offers = _service.GetOfferByUserId(currentUser.Id, productId);
            if (offers is null)
            {
                return BadRequest("Bu urune verdiginiz teklif yok");
            }
            var offerDto = _mapper.Map<OfferDto>(offers);

            return Ok(offerDto);
        }

        /// <summary>
        /// Kullanıcının verdiği bütün offerlar listelenir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Offers")]
        public async Task<IActionResult> ListUsersOffers()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var offers = await _service.Where(x => x.UserId == currentUser.Id).ToListAsync();
            if (offers is null)
            {
                return BadRequest("Teklifiniz yok");
            }
            var offerDtos = _mapper.Map<List<OfferDto>>(offers);
            
            return Ok(offerDtos);
        }


        /// <summary>
        /// Kullanıcının kendi ürünlerine yapılan offerları görebilir.
        /// </summary>
        /// <returns></returns>
        [HttpGet("OffersForUsersProduct")]
        public async Task<IActionResult> GetOfferUsersProduct()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var offers = await _productService.GetProductsWithOffers(currentUser.Id);
            if(offers is null)
            {
                return BadRequest("Urununuze verilen offer yok");
            }
            var OffersUsersProductsDto = _mapper.Map<List<OffersUsersProductsDto>>(offers);
            
            return Ok(OffersUsersProductsDto);
        }


        /// <summary>
        /// Kullanıcı ürüne verdiği teklifi geri cekebilir
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> BackOffer(int productId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var offer = _service.GetOfferByUserId(currentUser.Id, productId);
            if(offer == null)
            {
                return BadRequest("Bu ürüne verdiğiniz teklif yok");
            }
            await _service.RemoveAsync(offer);
            return Ok();
        }

        

       

    }
}

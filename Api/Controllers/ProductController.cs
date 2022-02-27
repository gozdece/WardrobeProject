using AutoMapper;
using Core.Dtos;
using Core.Dtos.ProductDto;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductService _service;
        private readonly UserManager<User> _userManager;

        public ProductController(IProductService service,IMapper mapper, UserManager<User> userManager) : base(mapper)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.ProductsWithDetail();
            var productDtos= _mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(productDtos);
        }
        [HttpPost]
        public async Task<IActionResult> Add(PostProductDto postProductDto)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var product = _mapper.Map<Product>(postProductDto);
            product.UserId = currentUser.Id;
            await _service.AddAsync(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            //return CreateActionResult(CustomResponseDto<ProductDto>.Success(204,productDto));
            return Ok(productDto);
        }
    }
}

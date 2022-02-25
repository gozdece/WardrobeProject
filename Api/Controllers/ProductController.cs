using AutoMapper;
using Core.Dtos;
using Core.Dtos.ProductDto;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IProductService _service;
        
        public ProductController(IProductService service,IMapper mapper) : base(mapper)
        {
            _service = service;
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
            var product = _mapper.Map<Product>(postProductDto);
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

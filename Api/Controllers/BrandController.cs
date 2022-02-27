using AutoMapper;
using Core.Dtos.BrandDto;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class BrandController : BaseController
    {
        private readonly IService<Brand> _service;
        public BrandController(IMapper mapper,IService<Brand> service) : base(mapper)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var brands = await _service.GetAllAsync();
            var brandDtos = _mapper.Map<List<BrandDto>>(brands.ToList());
            return Ok(brandDtos);
           
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(PostBrandDto postBrandDto)
        {
            var brand = _mapper.Map<Brand>(postBrandDto);
            await _service.AddAsync(brand);
            return Ok();
        }

    }
}

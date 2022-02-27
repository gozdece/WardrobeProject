using AutoMapper;
using Core.Dtos.CategoryDto;
using Core.Dtos.ColorDto;
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
    public class ColorController : BaseController
    {
        private readonly IService<Color> _service;
        public ColorController(IMapper mapper,IService<Color> service) : base(mapper)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           var colors = await _service.GetAllAsync();
           var colorDtos = _mapper.Map<List<ColorDto>>(colors.ToList());
           return Ok(colorDtos);
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostColorDto postColorDto)
        {
            var color = _mapper.Map<Color>(postColorDto);
            await _service.AddAsync(color);
            return Ok();
        }
    }
}

using AutoMapper;
using Core.Dtos.CategoryDto;
using Core.Models;
using Core.Services;
using Core.UnitOfWorks;
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

    public class CategoryController : BaseController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service,IMapper mapper) : base(mapper)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return Ok(categoryDtos);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(PostCategoryDto postCategoryDto)
        {
            var category = _mapper.Map<Category>(postCategoryDto);
            await _service.AddAsync(category);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            await _service.UpdateAsync(category);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = _service.GetByIdAsync(id).Result;
            await _service.RemoveAsync(category);
            return Ok();

        }

        [HttpGet("ProductsByCategoryId/{categoryId}")]
        public async Task<IActionResult> ProductsByCategoryId(int categoryId)
        {
            var category = await _service.CategoryWithProducts(categoryId);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }
    }
}

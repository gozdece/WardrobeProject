using AutoMapper;
using Core.Dtos.UsageStatus;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsageStatusController : BaseController
    {
        private readonly IService<UsageStatus> _service;
        public UsageStatusController(IMapper mapper,IService<UsageStatus> service) : base(mapper)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddUsageStatus(PostUsageStatusDto postUsageStatusDto)
        {
            var usageStatus = _mapper.Map<UsageStatus>(postUsageStatusDto);
           await _service.AddAsync(usageStatus);
            return Ok();
        }
    }
}

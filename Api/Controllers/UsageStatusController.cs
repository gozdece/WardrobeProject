using AutoMapper;
using Core.Dtos.UsageStatus;
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
    public class UsageStatusController : BaseController
    {
        private readonly IService<UsageStatus> _service;
        public UsageStatusController(IMapper mapper,IService<UsageStatus> service) : base(mapper)
        {
            _service = service;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await _service.GetAllAsync();
            var statusesDto = _mapper.Map<List<UsageStatusDto>>(statuses.ToList());
            return Ok(statusesDto);
            
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

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Mail;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailSender _mailService;

        public EmailController(IMailSender mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        public async Task<ActionResult> SendMail()
        {
            await _mailService.SendEmailAsync("kubilaykapl41@gmail.com", "Konu", "Mesaj gönderildi");
            return Ok();
        }

    }
}

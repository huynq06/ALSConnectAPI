using AlsConnect.Application.Interfaces;
using AlsConnect.Application.ViewModels.Email;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlsConnect.WebApi.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [Route("send")]
        [HttpPost]
        public async  Task<IActionResult> SendEmail(EmailModel emailModel)
        {
            var result = await _emailService.SendEmail(emailModel);
            return Ok(result);
        }
    }
}

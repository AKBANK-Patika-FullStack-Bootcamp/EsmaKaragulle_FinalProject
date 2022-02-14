using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public IActionResult SendMail(Mail mail)
        {
            var result = _mailService.Add(mail);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPut("open")]
        public IActionResult OpenMail(Mail mail)
        {
            var result = _mailService.Update(mail);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("getallsend")]
        public IActionResult GetAllSend(string mail)
        {
            var result = _mailService.SendGetAll(mail);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }


        [HttpGet("getallinbox")]
        public IActionResult GetAllInBox(string mail)
        {
            var result = _mailService.InboxGetAll(mail);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
    }
}

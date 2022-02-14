using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {

        private readonly ICreditCardService _creditCardService;

        public CreditCardController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetCreditCards()
        {
            return Ok(_creditCardService.GetCreditCards());
        }

        [HttpPost("addcreditcard")]
        public IActionResult AddCreditCart(CreditCard creditCard)
        {
            _creditCardService.AddCreditCard(creditCard);
            return Ok(creditCard);
        }
    }
}

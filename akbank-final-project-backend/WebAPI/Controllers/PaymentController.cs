using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("add")]
        public IActionResult PaymentAdd(Payment payment)
        {
            var result = _paymentService.Add(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("multipleadd")]
        public IActionResult MultiplePaymentAdd(MultipleAddDto multipleAdd)
        {
            var result = _paymentService.MultipleAdd(multipleAdd);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult PaymentUpdate(Payment payment)
        {
            var result = _paymentService.Update(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult PaymentDelete(Payment payment)
        {
            var result = _paymentService.Delete(payment);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok("Payment sil");
        }

        [HttpGet("getall")]
        public IActionResult GetAllPayment()
        {
            var result = _paymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetPaymentById(int id)
        {
            var result = _paymentService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybillingdate")]
        public IActionResult GetPaymentByBillingDate()
        {
            return Ok("billing date Payment");
        }

        [HttpGet("getbyduedate")]
        public IActionResult GetPaymentByDueDate()
        {
            return Ok("due date Payment");
        }

        [HttpGet("getbypastduedate")]
        public IActionResult GetPaymentByPastDueDate()
        {
            return Ok("past due date Payment");
        }


        [HttpGet("getbysuccesspayment")]
        public IActionResult GetPaymentBySuccessPayment()
        {
            return Ok("Success Payment");
        }



    }
}

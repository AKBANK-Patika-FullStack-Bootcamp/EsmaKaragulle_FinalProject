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
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceTypeService _invoiceTypeService;

        public InvoiceController(IInvoiceTypeService invoiceTypeService)
        {
            _invoiceTypeService = invoiceTypeService;
        }

        [HttpPost("add")]
        public IActionResult InvoiceAdd(InvoiceType invoiceType)
        {
            var result = _invoiceTypeService.Add(invoiceType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult InvoiceUpdate(InvoiceType invoiceType)
        {
            var result = _invoiceTypeService.Update(invoiceType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult InvoiceDelete(InvoiceType invoiceType)
        {
            var result = _invoiceTypeService.Delete(invoiceType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAllInvoice()
        {
            var result = _invoiceTypeService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetApartmentById(int id)
        {
            var result = _invoiceTypeService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


      
    }
}

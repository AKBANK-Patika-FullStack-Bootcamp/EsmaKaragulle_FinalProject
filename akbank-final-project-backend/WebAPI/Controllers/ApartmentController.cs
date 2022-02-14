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
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost("add")]
        public IActionResult ApartmentAdd(Apartment apartment)
        {
            var result = _apartmentService.Add(apartment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult ApartmentUpdate(Apartment apartment)
        {
            var result = _apartmentService.Update(apartment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult ApartmentDelete(Apartment apartment)
        {
            var result = _apartmentService.Update(apartment);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAllApartment()
        {
            var result = _apartmentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetApartmentById(int id)
        {
            var result = _apartmentService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyblockname")]
        public IActionResult GetApartmentByBlockNAme(string blockNo)
        {
            var result = _apartmentService.GetAllByBlockName(blockNo);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getbyblank")]
        public IActionResult GetApartmentByBlank()
        {
            var result = _apartmentService.GetAllByBlank();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyactive")]
        public IActionResult GetApartmentByActive()
        {
            var result = _apartmentService.GetAllByActive();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyblankactive")]
        public IActionResult GetApartmentByBlankActive()
        {
            var result = _apartmentService.GetAllByBlankAndActive();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }




        [HttpGet("getbyblankcount")]
        public IActionResult GetBlankApartmentCount()
        {
            var result = _apartmentService.BlankApartmentCount();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyactivecount")]
        public IActionResult GetActiveApartmentCount()
        {
            var result = _apartmentService.ActiveApartmentCount();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}

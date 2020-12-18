using CabBooking.Core.Entities;
using CabBooking.Core.Models.Reqpest;
using CabBooking.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;
        public AdminController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        [HttpPost]
        [Route("CabType")]
        public async Task<IActionResult> CreateCabType(CabTypeCreateRequest cabTypeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                var capTypeResponse = await _cabTypeService.CreateCabType(cabTypeCreateRequest);
                //TODO: should catch exception here
                return Ok(capTypeResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut]
        [Route("CabType")]
        public async Task<IActionResult> UpdateCabType(CabType cabType)
        {
            if (ModelState.IsValid)
            {
                var capTypeResponse = await _cabTypeService.UpdateCabType(cabType);
                //TODO: should catch exception here
                return Ok(capTypeResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpDelete]
        [Route("CabType/{cabTypeId:int}")]
        public async Task<IActionResult> UpdateCabType(int cabTypeId)
        {
            var response = await _cabTypeService.DeleteCabType(cabTypeId);
            if(response)
            {
                return Ok();
            }
            return BadRequest(new { message = "please correct the input information" });

        }


    }
}

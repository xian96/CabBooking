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
    }
}

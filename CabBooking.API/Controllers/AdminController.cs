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
        private readonly IPlaceService _placeService;

        public AdminController(ICabTypeService cabTypeService, IPlaceService placeService)
        {
            _cabTypeService = cabTypeService;
            _placeService = placeService;
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

        [HttpPost]
        [Route("Place")]
        public async Task<IActionResult> CreatePlace(Place place)
        {
            if (ModelState.IsValid)
            {
                var placeResponse = await _placeService.CreatePlace(place);
                //TODO: should catch exception here
                return Ok(placeResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut]
        [Route("Place")]
        public async Task<IActionResult> UpdatePlace(Place place)
        {
            if (ModelState.IsValid)
            {
                var placeResponse = await _placeService.UpdatePlace(place);
                //TODO: should catch exception here
                return Ok(placeResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpDelete]
        [Route("Place/{PlaceId:int}")]
        public async Task<IActionResult> UpdatePlace(int PlaceId)
        {
            var response = await _placeService.DeletePlace(PlaceId);
            if (response)
            {
                return Ok();
            }
            return BadRequest(new { message = "please correct the input information" });

        }

    }
}

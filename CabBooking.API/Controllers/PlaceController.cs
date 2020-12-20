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
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        //Should be able to Add/Update/Delete/List the places. (Kind of lookup, predefined locations)        
        [HttpGet]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllPlaces();
            if (places == null)
            {
                return NotFound("no places Found");
            }
            return Ok(places);
        }

        [HttpGet]
        [Route("{placeId:int}")]
        public async Task<IActionResult> GetPlaceById(int placeId)
        {
            var place = await _placeService.GetPlaceById(placeId);
            if (place == null)
            {
                return NotFound("no place Found");
            }
            return Ok(place);
        }
    }
}

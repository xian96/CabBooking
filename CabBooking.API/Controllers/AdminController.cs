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
        private readonly IBookingService _bookingService;
        private readonly IBookingHistoryService _bookingHistoryService;

        public AdminController(ICabTypeService cabTypeService, IPlaceService placeService, IBookingService bookingService, IBookingHistoryService bookingHistoryService)
        {
            _cabTypeService = cabTypeService;
            _placeService = placeService;
            _bookingService = bookingService;
            _bookingHistoryService = bookingHistoryService;
        }

        // ---------------------------------------- CabType -----------------------------------------------

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

        // ---------------------------------------- Place -----------------------------------------------

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

        // ---------------------------------------- Booking -----------------------------------------------

        [HttpPost]
        [Route("Booking")]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var bookingResponse = await _bookingService.CreateBooking(booking);
                //TODO: should catch exception here
                return Ok(bookingResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut]
        [Route("Booking")]
        public async Task<IActionResult> UpdateBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var bookingResponse = await _bookingService.UpdateBooking(booking);
                //TODO: should catch exception here
                return Ok(bookingResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpDelete]
        [Route("Booking/{bookingId:int}")]
        public async Task<IActionResult> UpdateBooking(int bookingId)
        {
            var response = await _bookingService.DeleteBooking(bookingId);
            if (response)
            {
                return Ok();
            }
            return BadRequest(new { message = "please correct the input information" });

        }

        // ---------------------------------------- BookingHistory -----------------------------------------------

        [HttpPost]
        [Route("BookingHistory")]
        public async Task<IActionResult> CreateBookingHistory(BookingHistory bookingHistory)
        {
            if (ModelState.IsValid)
            {
                var bookingHistoryResponse = await _bookingHistoryService.CreateBookingHistory(bookingHistory);
                //TODO: should catch exception here
                return Ok(bookingHistoryResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpPut]
        [Route("BookingHistory")]
        public async Task<IActionResult> UpdateBookingHistory(BookingHistory bookingHistory)
        {
            if (ModelState.IsValid)
            {
                var bookingHistoryResponse = await _bookingHistoryService.UpdateBookingHistory(bookingHistory);
                //TODO: should catch exception here
                return Ok(bookingHistoryResponse);
            }

            return BadRequest(new { message = "please correct the input information" });
        }

        [HttpDelete]
        [Route("BookingHistory/{bookingHistoryId:int}")]
        public async Task<IActionResult> UpdateBookingHistory(int bookingHistoryId)
        {
            var response = await _bookingHistoryService.DeleteBookingHistory(bookingHistoryId);
            if (response)
            {
                return Ok();
            }
            return BadRequest(new { message = "please correct the input information" });

        }

    }
}

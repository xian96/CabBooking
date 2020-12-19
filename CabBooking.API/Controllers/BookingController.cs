using CabBooking.Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JasonXing.CabBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCabTypes()
        {
            var bookings = await _bookingService.GetAllBooking();
            if (bookings == null)
            {
                return NotFound("no CabTypes Found");
            }
            return Ok(bookings);
        }

    }
}

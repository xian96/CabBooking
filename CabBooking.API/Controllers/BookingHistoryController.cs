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
    public class BookingHistoryController : ControllerBase
    {
        private readonly IBookingHistoryService _bookingHistoryService;

        public BookingHistoryController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookingHistory()
        {
            var bookingHistories = await _bookingHistoryService.GetAllBookingHistory();
            if (bookingHistories == null)
            {
                return NotFound("no bookingHistories Found");
            }
            return Ok(bookingHistories);
        }

        [HttpGet]
        [Route("{bookingHistoryId:int}")]
        public async Task<IActionResult> GetBookingHistoryById(int bookingHistoryId)
        {
            var bookingHistory = await _bookingHistoryService.GetBookingHistoryById(bookingHistoryId);
            if (bookingHistory == null)
            {
                return NotFound("no bookingHistory Found");
            }
            return Ok(bookingHistory);
        }
    }
}

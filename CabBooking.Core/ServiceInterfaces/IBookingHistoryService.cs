using CabBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface IBookingHistoryService
    {
        Task<IEnumerable<BookingHistory>> GetAllBookingHistory();
        Task<BookingHistory> CreateBookingHistory(BookingHistory bookingHistory);
        Task<BookingHistory> UpdateBookingHistory(BookingHistory bookingHistory);
        Task<bool> DeleteBookingHistory(int BookingHistoryId);
        Task<BookingHistory> GetBookingHistoryById(int bookingHistoryId);
    }
}

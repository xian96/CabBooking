

using CabBooking.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CabBooking.Core.ServiceInterfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBooking();
        Task<Booking> CreateBooking(Booking booking);
        Task<Booking> UpdateBooking(Booking booking);
        Task<bool> DeleteBooking(int bookingId);
        Task<Booking> GetBookingById(int bookingId);

    }
}

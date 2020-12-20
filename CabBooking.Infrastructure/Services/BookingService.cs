
using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            var exists = await _bookingRepository.GetExistsAsync(b => b.Id == booking.Id);

            if (exists)
            {
                throw new Exception("Movie Already Exits");
            }

            var createdBooking = await _bookingRepository.AddAsync(booking);

            // response model not used here, cause only two prop
            return booking;
        }

        public async Task<bool> DeleteBooking(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);

            if (booking == null)
            {
                throw new Exception("booking Not Found");
            }
            //TODO: try catch not added yet
            await _bookingRepository.DeleteAsync(booking);

            return true;
        }

        public async Task<IEnumerable<Booking>> GetAllBooking()
        {
            return await _bookingRepository.ListAllAsync();
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            var exists = await _bookingRepository.GetExistsAsync(b => b.Id == booking.Id);

            if (!exists)
            {
                throw new Exception("booking not Found");
            }

            var updatedBooking = await _bookingRepository.UpdateAsync(booking);

            // response model not used here, cause only two prop
            return updatedBooking;
        }

        public async Task<Booking> GetBookingById(int bookingId)
        {
            return await _bookingRepository.GetByIdAsync(bookingId);
        }
    }
}

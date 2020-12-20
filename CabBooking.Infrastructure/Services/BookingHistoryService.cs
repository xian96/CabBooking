using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IBookingHistoryRepository _bookingHistoryRepository;

        public BookingHistoryService(IBookingHistoryRepository bookingHistoryRepository)
        {
            _bookingHistoryRepository = bookingHistoryRepository;
        }

        public async Task<BookingHistory> CreateBookingHistory(BookingHistory bookingHistory)
        {
            var exists = await _bookingHistoryRepository.GetExistsAsync(b => b.Id == bookingHistory.Id);

            if (exists)
            {
                throw new Exception("bookingHistory Already Exits");
            }

            var createdBooking = await _bookingHistoryRepository.AddAsync(bookingHistory);

            // response model not used here, cause only two prop
            return bookingHistory;
        }

        public async Task<bool> DeleteBookingHistory(int bookingHistoryId)
        {
            var bookingHistory = await _bookingHistoryRepository.GetByIdAsync(bookingHistoryId);

            if (bookingHistory == null)
            {
                throw new Exception("bookingHistory Not Found");
            }
            //TODO: try catch not added yet
            await _bookingHistoryRepository.DeleteAsync(bookingHistory);

            return true;
        }

        public async Task<IEnumerable<BookingHistory>> GetAllBookingHistory()
        {
            return await _bookingHistoryRepository.ListAllAsync();
        }

        public async Task<BookingHistory> UpdateBookingHistory(BookingHistory bookingHistory)
        {
            var exists = await _bookingHistoryRepository.GetExistsAsync(b => b.Id == bookingHistory.Id);

            if (!exists)
            {
                throw new Exception("bookingHistory not Found");
            }

            var updatedBookingHistory = await _bookingHistoryRepository.UpdateAsync(bookingHistory);

            // response model not used here, cause only two prop
            return updatedBookingHistory;
        }

        public async Task<BookingHistory> GetBookingHistoryById(int bookingHistoryId)
        {
            return await _bookingHistoryRepository.GetByIdAsync(bookingHistoryId);
        }
    }
}

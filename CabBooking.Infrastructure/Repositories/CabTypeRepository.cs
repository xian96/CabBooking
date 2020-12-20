
using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabBooking.Infrastructure.Repositories
{
    public class CabTypeRepository : EfRepository<CabType>, ICabTypeRepository
    {
        public CabTypeRepository(CabBookingDbContext dbContext): base(dbContext)
        {
        }

        // additional method for cabtype repo
        public override async Task<CabType> GetByIdAsync(int id)
        {

            /*            var cabType = await _dbContext.CabTypes.Where(c => c.CabTypeId == id).FirstOrDefaultAsync(c => c.CabTypeId == id);
                        var bookings = await _dbContext.Bookings.Where(b => b.CabTypeId == id).ToListAsync();
                        foreach (var booking in bookings)
                        {
                            var fromPlace = await _dbContext.Places.Where(p => p.PlaceId == booking.FromPlaceId).FirstOrDefaultAsync();
                            var toPlace = await _dbContext.Places.Where(p => p.PlaceId == booking.ToPlaceId).FirstOrDefaultAsync();
                            booking.FromPlace = fromPlace;
                            booking.ToPlace = toPlace;
                        }
                        cabType.Bookings = bookings;*/


            var cabType = await _dbContext.CabTypes.Where(c => c.CabTypeId == id)
                    .Include(c => c.Bookings).ThenInclude(b => b.FromPlace)
                    .Include(c => c.Bookings).ThenInclude(b => b.ToPlace)
                    .Include(c => c.BookingHistories).ThenInclude(b => b.FromPlace)
                    .Include(c => c.BookingHistories).ThenInclude(b => b.ToPlace)
                    .FirstOrDefaultAsync(c => c.CabTypeId == id);


            if (cabType == null) return null;
            return cabType;
        }
    }
}

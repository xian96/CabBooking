
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
            var cabType = await _dbContext.CabTypes.Where(c => c.CabTypeId == id)
                .Include(c => c.Bookings)
                .ThenInclude(b => b.FromPlace)
                .Include(c => c.Bookings)
                .ThenInclude(b => b.ToPlace)
                .Include(c => c.BookingHistories)
                .ThenInclude(b => b.FromPlace)
                .Include(c => c.BookingHistories)
                .ThenInclude(b => b.ToPlace)
                .FirstOrDefaultAsync(m => m.CabTypeId == id);
            if (cabType == null) return null;
            return cabType;
        }
    }
}

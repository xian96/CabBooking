using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Infrastructure.Repositories
{
    public class BookingRepository : EfRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CabBookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}

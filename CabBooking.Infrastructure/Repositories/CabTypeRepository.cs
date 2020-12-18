
using CabBooking.Core.Entities;
using CabBooking.Core.RepositoryInterfaces;
using CabBooking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Infrastructure.Repositories
{
    public class CabTypeRepository : EfRepository<CabType>, ICabTypeRepository
    {
        public CabTypeRepository(CabBookingDbContext dbContext): base(dbContext)
        {
        }


    }
}

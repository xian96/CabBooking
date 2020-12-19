using CabBooking.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.RepositoryInterfaces
{
    public interface IBookingHistoryRepository : IAsyncRepository<BookingHistory>
    {
    }
}

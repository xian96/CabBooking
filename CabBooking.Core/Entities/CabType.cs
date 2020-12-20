using System.Collections.Generic;

namespace CabBooking.Core.Entities
{
    public class CabType
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }

        //navigation
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<BookingHistory> BookingHistories { get; set; }

    }
}

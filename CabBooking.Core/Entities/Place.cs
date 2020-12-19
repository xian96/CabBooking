/*
 https://stackoverflow.com/questions/59274852/ef-models-navigation-properties-can-only-participate-in-a-single-relationship
 
 */


using System.Collections.Generic;

namespace CabBooking.Core.Entities
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }

        //navigation
        public ICollection<Booking> FromBookings { get; set; }
        public ICollection<Booking> ToBookings { get; set; }

        public ICollection<BookingHistory> FromBookingHistories { get; set; }
        public ICollection<BookingHistory> ToBookingHistories { get; set; }
    }
}

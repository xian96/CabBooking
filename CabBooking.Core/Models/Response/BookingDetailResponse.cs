using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.Models.Response
{
    public class BookingDetailResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingTime { get; set; }
        //change the prop name from 'FromPlace' to 'FromPlaceId' cause here it is the froeign key id. it more properate to call it id
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupTime { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }

        public PlaceResponse FromPlace { get; set; }
        public PlaceResponse ToPlace { get; set; }
    }
}

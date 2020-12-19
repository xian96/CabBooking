using System;

namespace CabBooking.Core.Entities
{
    public class BookingHistory
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingTime { get; set; }
        //change the prop name from 'FromPlace' to 'FromPlaceId' cause here it is the foreign key id. it more properate to call it id
        public int? FromPlaceId { get; set; }//foreign key
        //same with fromplaceid
        public int? ToPlaceId { get; set; }//foreign key
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }//foreign key
        public string ContactNo { get; set; }
        public string Status { get; set; }
        // name int database ER diagram 'comp_time' , changed cause the C# naming
        public string CompTime { get; set; }
        public decimal? Charge { get; set; }
        public string FeedBack { get; set; }

        //navigation prop
        public Place FromPlace { get; set; }
        public Place ToPlace { get; set; }
        public CabType CabType { get; set; }


    }
}

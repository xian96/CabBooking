using System;
using System.Collections.Generic;
using System.Text;

namespace CabBooking.Core.Models.Response
{
    public class CabTypeDetailResponse
    {
        public int CabTypeId { get; set; }

        public string CabTypeName { get; set; }

        public List<BookingDetailResponse> BookingDetailResponses { get; set; }

    }
}

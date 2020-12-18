using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CabBooking.Core.Models.Reqpest
{
    public class CabTypeCreateRequest
    {
        public int CabTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string CabTypeName { get; set; }
    }
}

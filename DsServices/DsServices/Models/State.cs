using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public partial class State
    {
        [Key]
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public string Active { get; set; }

        public virtual Country Country { get; set; }
    }
}

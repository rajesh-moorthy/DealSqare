using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public partial class Country
    {
        public Country()
        {
            State = new HashSet<State>();
        }
        [Key]
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string Active { get; set; }

        public virtual ICollection<State> State { get; set; }
    }
}

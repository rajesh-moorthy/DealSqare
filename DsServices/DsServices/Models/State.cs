using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public partial class State
    {
        [Key]
        public int ID { get; set; }
        public int CountryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }

        public virtual Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public partial class State
    {
        [Key]
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }

        public virtual Country Country { get; set; }
    }
}

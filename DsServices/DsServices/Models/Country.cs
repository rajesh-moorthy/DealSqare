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
        public int Id { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }

        public virtual ICollection<State> State { get; set; }
    }
}

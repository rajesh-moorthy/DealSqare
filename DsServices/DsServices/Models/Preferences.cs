using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public class Preferences
    {
        [Key]
        public int PreferenceId { get; set; }

        public string PreferenceName { get; set; }

        public int Active { get; set; }
    }
}

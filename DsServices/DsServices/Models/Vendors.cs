using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        
        public string EmailId { get; set; }

        public string MobileNumber { get; set; }

        public string Password { get; set; }

        public int TownId { get; set; }

        public string UserName { get; set; }

        public int VendorBusiness { get; set; }

        public int Active { get; set; }

        public virtual City Vcity { get; set; }

        public virtual Preferences VBusiness { get; set; }
    }
}

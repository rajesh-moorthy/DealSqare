using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public class City
    {
        [Key]
        public Int32 CityId { get; set; }

        public string CountryCode { get; set; }
       
        public string PostalCode { get; set; }

        public string Village { get; set; }
        
        public string State { get; set; }
        
        public string StateID { get; set; }
        
        public string CityName { get; set; }
        
        public string Town { get; set; }
        
        public string Cord1 { get; set; }
        
        public string Cord2 { get; set; }

        public int Active { get; set; }

        public Customer CustCity { get; set; }

        public Vendors VendCity { get; set; }
    }
}

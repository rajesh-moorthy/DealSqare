using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public string LogDescription { get; set; }

        public DateTime LogDate { get; set; }

    }
}

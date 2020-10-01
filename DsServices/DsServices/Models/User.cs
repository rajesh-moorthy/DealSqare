using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DsServices.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public DateTime Created { get; set; }

        //public virtual ICollection<Credential> Credentials { get; set; }
    }
}

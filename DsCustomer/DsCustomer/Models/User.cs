﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DsCustomer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
   
        public int UserType  {get;set;}

        public DateTime Created { get; set; }
    }
}

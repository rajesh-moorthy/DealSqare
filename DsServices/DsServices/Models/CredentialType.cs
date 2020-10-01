using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DsServices.Models
{
    public class CredentialType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Position { get; set; }

        public virtual ICollection<Credential> Credentials { get; set; }
    }
}

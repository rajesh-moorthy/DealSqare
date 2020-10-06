using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DsServices.Models;
using Microsoft.EntityFrameworkCore;
using DsServices.Repository;

namespace DsServices.Controllers
{
    public class VendorController: ControllerBase
    {

        [HttpGet("api/GetVendorsByMobile/{Mobile}")]
        public async Task<IList<VendorData>> GetVendorsByMobile(string Mobile)
        {
            var db = new DsContext();
            var user = from s in db.Vendor
                       where s.MobileNumber == Mobile
                       select new VendorData()
                       {
                           VendorId = s.VendorId,
                           VendorName = s.VendorName,
                           Password = s.Password,
                           MobileNumber = s.MobileNumber,
                           EmailId = s.EmailId
                       };


            return (IList<VendorData>)await user.ToListAsync();
        }




        [HttpPost("api/CreateVendor/{vendor}")]
        public async Task CreateVendor(Vendors vendor)
        {
            var db = new DsContext();
            await db.Vendor.AddAsync(vendor);
            await db.SaveChangesAsync();
        }

        //[HttpPost]

        //// DELETE: api/DeletePatient/5
        //[HttpDelete("{id}")]
        //public async Task DeletePatient(int id)
        //{
        //    var db = new DsContext();
        //    var user = await db.Users.FindAsync(id);
        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();
        //}

        public class VendorData
        {
            public int VendorId { get; set; }

            public string VendorName { get; set; }

            public string MobileNumber { get; set; }

            public string EmailId { get; set; }

            public string Password { get; set; }
        }
    }
}

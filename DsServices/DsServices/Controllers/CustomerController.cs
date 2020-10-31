using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DsServices.Models;
using Microsoft.EntityFrameworkCore;

namespace DsServices.Controllers
{
    public class CustomerController : ControllerBase
    {

        [HttpGet("api/GetUsersByMobile/{Mobile}")]
        public async Task<IList<UserData>> GetUsersByMobile(string Mobile)
        {
            var db = new DsContext();
            var user = from s in db.customer
                       where s.MobileNumber == Mobile
                       select new UserData()
                       {
                           UserId = s.CustomerId,
                           CustomerName = s.CustomerName,
                           Password = s.Password,
                           MobileNumber=s.MobileNumber,
                           EmailId=s.EmailId
                       };


            return (IList<UserData>) await user.ToListAsync();
        }

        


        [HttpPost("api/CreateCustomer/{customer}")]
        public async Task CreateCustomer(Customer customer)
        {
            var db = new DsContext();
            await db.customer.AddAsync(customer);
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

        public class UserData
        {
            public int UserId { get; set; }

            public string CustomerName { get; set; }

            public string MobileNumber { get; set; }

            public string EmailId { get; set; }

            public string Password { get; set; }
        }

    }

  

}





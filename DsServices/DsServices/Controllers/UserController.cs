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
    public class UserController : ControllerBase
    {

        [HttpGet("api/GetUsersByMobile/{Mobile}")]
        public async Task<IList<UserData>> GetUsersByMobile(string Mobile)
        {
            var db = new DsContext();
            var user = from s in db.Users
                       where s.Mobile == Mobile
                       select new UserData()
                       {
                           UserId = s.Id,
                           CustomerName = s.Name,
                           Password = s.Password,
                           MobileNumber=s.Mobile,
                           EmailId=s.Email
                       };


            return (IList<UserData>) await user.ToListAsync();
        }

        


        [HttpPost("api/CreateUser/{user}")]
        public async Task CreateUser(User user)
        {
            var db = new DsContext();
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }

        [HttpPost]

        // DELETE: api/DeletePatient/5
        [HttpDelete("{id}")]
        public async Task DeletePatient(int id)
        {
            var db = new DsContext();
            var user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
        }

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





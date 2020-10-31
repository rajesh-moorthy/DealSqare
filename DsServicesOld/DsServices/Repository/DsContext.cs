using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DsServices.Models;

namespace DsServices.Repository
{
    public class DsContext : DbContext
    {
       

        public DbSet<City> city { get; set; }
       
        public virtual DbSet<Country> Country { get; set; }
     
        public virtual DbSet<State> State { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Vendors> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Rajesh@1234!;database=Dealsqare");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DsServices.Models
{
    public partial class DsContext : DbContext
    {
        public DsContext()
        {
        }

        public DsContext(DbContextOptions<DsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }

        public virtual DbSet<Country> Country { get; set; }

        public virtual DbSet<State> State { get; set; }

        public virtual DbSet<Customer> customer { get; set; }

        public virtual DbSet<Vendors> vendors { get; set; }

        public virtual DbSet<Preferences> preferences { get; set; }

        public virtual DbSet<Log> logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Rajesh@1234!;database=dealsqare");
            }
        }


      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer", "dealsqare");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerName)
                   .HasColumnName("CustomerName")
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.CustomerTown)
                    .HasColumnType("int(11)")
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                  .IsRequired()
                  .HasMaxLength(10)
                  .IsUnicode(false);

                entity.Property(e => e.Password)
                   .IsRequired()
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.Preferences)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.TotalPoints)
                   .HasColumnType("int(11)")
                   .IsUnicode(false);

                entity.Property(e => e.PointsRedeemed)
                   .HasColumnType("int(11)")
                   .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("date");

                modelBuilder.Entity<City>()
                    .HasOne(a => a.CustCity)
                    .WithOne(b => b.city)
                    .HasForeignKey<Customer>(b => b.CustomerTown);

            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.ToTable("vendors", "dealsqare");

                entity.Property(e => e.VendorId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.VendorName)
                   .HasColumnName("CustomerName")
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.Property(e => e.VendorBusiness)
                    .HasColumnType("int(11)")
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                  .IsRequired()
                  .HasMaxLength(10)
                  .IsUnicode(false);

                entity.Property(e => e.Password)
                   .IsRequired()
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.TownId)
                   .HasColumnType("int(11)")
                   .IsUnicode(false);

                entity.Property(e => e.Active)
                   .HasColumnType("int(11)")
                   .IsUnicode(false);

                modelBuilder.Entity<City>()
                  .HasOne(a => a.VendCity)
                  .WithOne(b => b.Vcity)
                  .HasForeignKey<Vendors>(b => b.TownId);


            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country", "dealsqare");

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                  .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state", "dealsqare");

                entity.HasIndex(e => e.CountryID)
                    .HasName("FK_State_Country");

                entity.Property(e => e.ID)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                   .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CountryID)
                    .HasColumnName("CountryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State_Country");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city", "dealsqare");

                entity.Property(e => e.CityId)
                    .HasColumnName("CityID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("N");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Cord1)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Cord2)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.StateID)
                    .IsRequired()
                    .HasColumnName("StateID")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Town)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Village)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Preferences>(entity =>
            {
                entity.ToTable("preferences", "dealsqare");

                entity.Property(e => e.PreferenceId)
                    .HasColumnName("PreferenceId")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Active)
                  .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PreferenceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Log>(entity => {

                entity.ToTable("log", "dealsqare");

                entity.Property(e => e.LogId)
                    .HasColumnName("LogId")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LogDescription)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.LogDate).HasColumnType("date");

            });


        }
    }
}

using Microsoft.EntityFrameworkCore;
using MPD.Entities.Data;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPD.Repository
{
    public partial class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<AcceptedQuote> AcceptedQuote { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerContact> CustomerContact { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobComment> JobComment { get; set; }
        public virtual DbSet<JobQuote> JobQuote { get; set; }
        public virtual DbSet<MachineShop> MachineShop { get; set; }
        public virtual DbSet<MachineShopContact> MachineShopContact { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<NotificationPreference> NotificationPreference { get; set; }
        public virtual DbSet<PartialShipment> PartialShipment { get; set; }
        public virtual DbSet<ReleasedAbout> ReleasedAbout { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcceptedQuote>()
                .Property(e => e.PONumber)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street1)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street2)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Customer)
                .WithOne(e => e.Address).IsRequired()
                .HasForeignKey(e => e.BillingAddressId);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.Customer1)
                .WithOne(e => e.Address1).IsRequired()
                .HasForeignKey(e => e.ShippingAddressId);

            modelBuilder.Entity<Address>()
                .HasMany(e => e.MachineShop)
                .WithOne(e => e.Address).IsRequired();

            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactType)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.ContactNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.CustomerContact)
                .WithOne(e => e.Contact).IsRequired();

            modelBuilder.Entity<Contact>()
                .HasMany(e => e.MachineShopContact)
                .WithOne(e => e.Contact).IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.EIN)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerContact)
                .WithOne(e => e.Customer).IsRequired();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Job)
                .WithOne(e => e.Customer).IsRequired();

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Document)
                .WithOne(e => e.DocumentType1).IsRequired()
                .HasForeignKey(e => e.DocumentType);

            modelBuilder.Entity<Job>()
                 .Property(e => e.DrawingNumber)
                 .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.Material)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.Revision)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .HasMany(e => e.Document)
                .WithOne(e => e.Job).IsRequired()
                .HasForeignKey(e => e.QuoteId);

            modelBuilder.Entity<Job>()
               .HasMany(e => e.JobQuote)
               .WithOne(e => e.Job).IsRequired();

            modelBuilder.Entity<Job>()
                .HasMany(e => e.PartialShipment1)
                .WithOne(e => e.Job).IsRequired()
                .HasForeignKey(e => e.QuoteId);

            modelBuilder.Entity<JobQuote>()
                .HasMany(e => e.AcceptedQuote)
                .WithOne(e => e.JobQuote).IsRequired();

            modelBuilder.Entity<JobQuote>()
                .HasMany(e => e.JobComment)
                .WithOne(e => e.JobQuote).IsRequired();

            modelBuilder.Entity<MachineShop>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<MachineShop>()
                .Property(e => e.SkillSet)
                .IsUnicode(false);

            modelBuilder.Entity<MachineShop>()
                .HasMany(e => e.JobQuote)
                .WithOne(e => e.MachineShop).IsRequired()
                .HasForeignKey(e => e.MachinShopId);

            modelBuilder.Entity<MachineShop>()
                .HasMany(e => e.MachineShopContact)
                .WithOne(e => e.MachineShop).IsRequired()
                .HasForeignKey(e => e.MachinShopId);

            modelBuilder.Entity<ReleasedAbout>()
                .Property(e => e.ReleasedAbout1)
                .IsUnicode(false);

            modelBuilder.Entity<ReleasedAbout>()
                .HasMany(e => e.Job)
                .WithOne(e => e.ReleasedAbout1).IsRequired()
                .HasForeignKey(e => e.ReleasedAbout);

            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Job)
                .WithOne(e => e.Status1).IsRequired()
                .HasForeignKey(e => e.Status);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.JobQuote)
                .WithOne(e => e.Status1).IsRequired()
                .HasForeignKey(e => e.Status);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.UserLogin)
                .WithOne(e => e.Status1).IsRequired()
                .HasForeignKey(e => e.Status);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogin>()
                .HasMany(e => e.Customer)
                .WithOne(e => e.UserLogin).IsRequired()
                .HasForeignKey(e => e.LoginId);

            modelBuilder.Entity<UserLogin>()
                .HasMany(e => e.Job)
                .WithOne(e => e.UserLogin).IsRequired()
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<UserLogin>()
                .HasMany(e => e.JobComment)
                .WithOne(e => e.UserLogin).IsRequired()
                .HasForeignKey(e => e.CommentBy);

            modelBuilder.Entity<UserLogin>()
              .HasMany(e => e.JobQuote)
              .WithOne(e => e.UserLogin).IsRequired()
              .HasForeignKey(e => e.MachinShopId);

            modelBuilder.Entity<UserLogin>()
                .HasMany(e => e.MachineShop)
                .WithOne(e => e.UserLogin).IsRequired()
                .HasForeignKey(e => e.LoginId);

            modelBuilder.Entity<UserLogin>()
                .HasMany(e => e.Notification)
                .WithOne(e => e.UserLogin).IsRequired()
                .HasForeignKey(e => e.NotificationFor);

            modelBuilder.Entity<UserLogin>()
                .HasMany(e => e.NotificationPreference)
                .WithOne(e => e.UserLogin).IsRequired();

            modelBuilder.Entity<UserType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<UserType>()
                .HasMany(e => e.UserLogin)
                .WithOne(e => e.UserType1).IsRequired()
                .HasForeignKey(e => e.UserType);
        }
    }
}

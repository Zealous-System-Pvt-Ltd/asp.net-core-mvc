using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MPD.Entities.Domain;

namespace MPD.Repository
{
    public partial class MPDContext : DbContext
    {
        public MPDContext()
        {
        }

        private readonly string _connectionString;
        public MPDContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }

        public MPDContext(DbContextOptions<MPDContext> options)
            : base(options)
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcceptedQuote>(entity =>
            {
                entity.Property(e => e.AcceptedQuoteId).ValueGeneratedNever();

                entity.Property(e => e.Ponumber).IsUnicode(false);

                entity.HasOne(d => d.JobQuote)
                    .WithMany(p => p.AcceptedQuote)
                    .HasForeignKey(d => d.JobQuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcceptedQuote_JobQuote");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).ValueGeneratedNever();

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.Street1).IsUnicode(false);

                entity.Property(e => e.Street2).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactId).ValueGeneratedNever();

                entity.Property(e => e.ContactNumber).IsUnicode(false);

                entity.Property(e => e.ContactType).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CompanyName).IsUnicode(false);

                entity.Property(e => e.Ein).IsUnicode(false);

                entity.Property(e => e.FullName).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.CustomerBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Address");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_UserLogin");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.CustomerShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_Address1");
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.Property(e => e.CustomerContactId).ValueGeneratedNever();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.CustomerContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerContact_Contact");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContact)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerContact_Customer");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId).ValueGeneratedNever();

                entity.HasOne(d => d.DocumentTypeNavigation)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_DocumentType");

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Document_Quote");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.DocumentTypeId).ValueGeneratedNever();

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId).ValueGeneratedNever();

                entity.Property(e => e.DrawingNumber).IsUnicode(false);

                entity.Property(e => e.Material).IsUnicode(false);

                entity.Property(e => e.Revision).IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Customer");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.ModifiedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_UserLogin");

                entity.HasOne(d => d.ReleasedAboutNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.ReleasedAbout)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_ReleasedAbout");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quote_Status");
            });

            modelBuilder.Entity<JobComment>(entity =>
            {
                entity.Property(e => e.JobCommentId).ValueGeneratedNever();

                entity.HasOne(d => d.CommentByNavigation)
                    .WithMany(p => p.JobComment)
                    .HasForeignKey(d => d.CommentBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobComment_UserLogin");

                entity.HasOne(d => d.JobQuote)
                    .WithMany(p => p.JobComment)
                    .HasForeignKey(d => d.JobQuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobComment_JobQuote");
            });

            modelBuilder.Entity<JobQuote>(entity =>
            {
                entity.Property(e => e.JobQuoteId).ValueGeneratedNever();

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobQuote)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobQuote_Job");

                entity.HasOne(d => d.MachinShop)
                    .WithMany(p => p.JobQuote)
                    .HasForeignKey(d => d.MachinShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobQuote_MachineShop");

                entity.HasOne(d => d.MachinShopNavigation)
                    .WithMany(p => p.JobQuote)
                    .HasForeignKey(d => d.MachinShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobQuote_UserLogin");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.JobQuote)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobQuote_Status");
            });

            modelBuilder.Entity<MachineShop>(entity =>
            {
                entity.Property(e => e.MachineShopId).ValueGeneratedNever();

                entity.Property(e => e.SkillSet).IsUnicode(false);

                entity.Property(e => e.ZipCode).IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.MachineShop)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineShop_Address");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.MachineShop)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineShop_UserLogin");
            });

            modelBuilder.Entity<MachineShopContact>(entity =>
            {
                entity.Property(e => e.MachineShopContactId).ValueGeneratedNever();

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.MachineShopContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineShopContact_Contact");

                entity.HasOne(d => d.MachinShop)
                    .WithMany(p => p.MachineShopContact)
                    .HasForeignKey(d => d.MachinShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineShopContact_MachineShop");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).ValueGeneratedNever();

                entity.HasOne(d => d.NotificationForNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.NotificationFor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_UserLogin");
            });

            modelBuilder.Entity<NotificationPreference>(entity =>
            {
                entity.Property(e => e.NotificationPreferenceId).ValueGeneratedNever();

                entity.HasOne(d => d.UserLogin)
                    .WithMany(p => p.NotificationPreference)
                    .HasForeignKey(d => d.UserLoginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotificationPreference_UserLogin");
            });

            modelBuilder.Entity<PartialShipment>(entity =>
            {
                entity.Property(e => e.PartialShipmentId).ValueGeneratedNever();

                entity.HasOne(d => d.Quote)
                    .WithMany(p => p.PartialShipmentNavigation)
                    .HasForeignKey(d => d.QuoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartialShipment_Quote");
            });

            modelBuilder.Entity<ReleasedAbout>(entity =>
            {
                entity.Property(e => e.ReleasedAboutId).ValueGeneratedNever();

                entity.Property(e => e.ReleasedAbout1).IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.Status1).IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.Property(e => e.UserLoginId).ValueGeneratedNever();

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_Status");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).ValueGeneratedNever();

                entity.Property(e => e.Type).IsUnicode(false);
            });
        }
    }
}

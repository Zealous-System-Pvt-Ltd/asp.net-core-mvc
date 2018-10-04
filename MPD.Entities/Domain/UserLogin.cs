using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class UserLogin
    {
        public UserLogin()
        {
            Customer = new HashSet<Customer>();
            Job = new HashSet<Job>();
            JobComment = new HashSet<JobComment>();
            JobQuote = new HashSet<JobQuote>();
            MachineShop = new HashSet<MachineShop>();
            Notification = new HashSet<Notification>();
            NotificationPreference = new HashSet<NotificationPreference>();
        }

        public Guid UserLoginId { get; set; }
        [Required]
        [StringLength(250)]
        public string Username { get; set; }
        [Required]
        [MaxLength(250)]
        public byte[] Password { get; set; }
        public short Status { get; set; }
        [Required]
        [StringLength(320)]
        public string Email { get; set; }
        public short UserType { get; set; }

        [ForeignKey("Status")]
        [InverseProperty("UserLogin")]
        public Status StatusNavigation { get; set; }
        [ForeignKey("UserType")]
        [InverseProperty("UserLogin")]
        public UserType UserTypeNavigation { get; set; }
        [InverseProperty("Login")]
        public ICollection<Customer> Customer { get; set; }
        [InverseProperty("ModifiedByNavigation")]
        public ICollection<Job> Job { get; set; }
        [InverseProperty("CommentByNavigation")]
        public ICollection<JobComment> JobComment { get; set; }
        [InverseProperty("MachinShopNavigation")]
        public ICollection<JobQuote> JobQuote { get; set; }
        [InverseProperty("Login")]
        public ICollection<MachineShop> MachineShop { get; set; }
        [InverseProperty("NotificationForNavigation")]
        public ICollection<Notification> Notification { get; set; }
        [InverseProperty("UserLogin")]
        public ICollection<NotificationPreference> NotificationPreference { get; set; }
    }
}

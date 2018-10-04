using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Status
    {
        public Status()
        {
            Job = new HashSet<Job>();
            JobQuote = new HashSet<JobQuote>();
            UserLogin = new HashSet<UserLogin>();
        }

        public short StatusId { get; set; }
        [Required]
        [Column("Status")]
        [StringLength(50)]
        public string Status1 { get; set; }

        [InverseProperty("StatusNavigation")]
        public ICollection<Job> Job { get; set; }
        [InverseProperty("StatusNavigation")]
        public ICollection<JobQuote> JobQuote { get; set; }
        [InverseProperty("StatusNavigation")]
        public ICollection<UserLogin> UserLogin { get; set; }
    }
}

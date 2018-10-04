using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class ReleasedAbout
    {
        public ReleasedAbout()
        {
            Job = new HashSet<Job>();
        }

        public short ReleasedAboutId { get; set; }
        [Required]
        [Column("ReleasedAbout")]
        [StringLength(50)]
        public string ReleasedAbout1 { get; set; }

        [InverseProperty("ReleasedAboutNavigation")]
        public ICollection<Job> Job { get; set; }
    }
}

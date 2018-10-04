using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Notification
    {
        public Guid NotificationId { get; set; }
        [Required]
        [StringLength(500)]
        public string NotificationText { get; set; }
        public Guid NotificationFor { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        public short Status { get; set; }

        [ForeignKey("NotificationFor")]
        [InverseProperty("Notification")]
        public UserLogin NotificationForNavigation { get; set; }
    }
}

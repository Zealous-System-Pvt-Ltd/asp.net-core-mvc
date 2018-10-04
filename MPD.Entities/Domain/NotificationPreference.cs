using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class NotificationPreference
    {
        public Guid NotificationPreferenceId { get; set; }
        public short PreferenceType { get; set; }
        public Guid UserLoginId { get; set; }

        [ForeignKey("UserLoginId")]
        [InverseProperty("NotificationPreference")]
        public UserLogin UserLogin { get; set; }
    }
}

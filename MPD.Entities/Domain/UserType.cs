using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class UserType
    {
        public UserType()
        {
            UserLogin = new HashSet<UserLogin>();
        }

        public short UserTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [InverseProperty("UserTypeNavigation")]
        public ICollection<UserLogin> UserLogin { get; set; }
    }
}

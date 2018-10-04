using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Contact
    {
        public Contact()
        {
            CustomerContact = new HashSet<CustomerContact>();
            MachineShopContact = new HashSet<MachineShopContact>();
        }

        public Guid ContactId { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactType { get; set; }
        [Required]
        [StringLength(20)]
        public string ContactNumber { get; set; }
        public bool IsPrimary { get; set; }

        [InverseProperty("Contact")]
        public ICollection<CustomerContact> CustomerContact { get; set; }
        [InverseProperty("Contact")]
        public ICollection<MachineShopContact> MachineShopContact { get; set; }
    }
}

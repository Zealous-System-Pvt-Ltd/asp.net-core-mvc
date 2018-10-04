using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class MachineShop
    {
        public MachineShop()
        {
            JobQuote = new HashSet<JobQuote>();
            MachineShopContact = new HashSet<MachineShopContact>();
        }

        public Guid MachineShopId { get; set; }
        public Guid LoginId { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
        public Guid AddressId { get; set; }
        [Required]
        public string SkillSet { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("MachineShop")]
        public Address Address { get; set; }
        [ForeignKey("LoginId")]
        [InverseProperty("MachineShop")]
        public UserLogin Login { get; set; }
        [InverseProperty("MachinShop")]
        public ICollection<JobQuote> JobQuote { get; set; }
        [InverseProperty("MachinShop")]
        public ICollection<MachineShopContact> MachineShopContact { get; set; }
    }
}

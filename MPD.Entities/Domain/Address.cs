using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Address
    {
        public Address()
        {
            CustomerBillingAddress = new HashSet<Customer>();
            CustomerShippingAddress = new HashSet<Customer>();
            MachineShop = new HashSet<MachineShop>();
        }

        public Guid AddressId { get; set; }
        [Required]
        [StringLength(250)]
        public string Street1 { get; set; }
        [StringLength(250)]
        public string Street2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("BillingAddress")]
        public ICollection<Customer> CustomerBillingAddress { get; set; }
        [InverseProperty("ShippingAddress")]
        public ICollection<Customer> CustomerShippingAddress { get; set; }
        [InverseProperty("Address")]
        public ICollection<MachineShop> MachineShop { get; set; }
    }
}

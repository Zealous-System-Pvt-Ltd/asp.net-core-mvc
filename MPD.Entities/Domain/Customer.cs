using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerContact = new HashSet<CustomerContact>();
            Job = new HashSet<Job>();
        }

        public Guid CustomerId { get; set; }
        public Guid LoginId { get; set; }
        [Required]
        [StringLength(250)]
        public string FullName { get; set; }
        [Required]
        [StringLength(250)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }
        public Guid BillingAddressId { get; set; }
        public Guid ShippingAddressId { get; set; }
        [Required]
        [Column("EIN")]
        [StringLength(50)]
        public string Ein { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BillingAddressId")]
        [InverseProperty("CustomerBillingAddress")]
        public Address BillingAddress { get; set; }
        [ForeignKey("LoginId")]
        [InverseProperty("Customer")]
        public UserLogin Login { get; set; }
        [ForeignKey("ShippingAddressId")]
        [InverseProperty("CustomerShippingAddress")]
        public Address ShippingAddress { get; set; }
        [InverseProperty("Customer")]
        public ICollection<CustomerContact> CustomerContact { get; set; }
        [InverseProperty("Customer")]
        public ICollection<Job> Job { get; set; }
    }
}

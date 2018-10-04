using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Job
    {
        public Job()
        {
            Document = new HashSet<Document>();
            JobQuote = new HashSet<JobQuote>();
            PartialShipmentNavigation = new HashSet<PartialShipment>();
        }

        public Guid JobId { get; set; }
        [Required]
        public string PartDescription { get; set; }
        [Required]
        [StringLength(50)]
        public string DrawingNumber { get; set; }
        [StringLength(50)]
        public string Material { get; set; }
        public int Quantity { get; set; }
        [StringLength(50)]
        public string Revision { get; set; }
        public bool PartialShipment { get; set; }
        public bool IsSupplyRawMaterial { get; set; }
        [StringLength(50)]
        public string RawmaterialDimensions { get; set; }
        public bool IsMaterialCertificationRequired { get; set; }
        public bool IsPartFromCasting { get; set; }
        [StringLength(500)]
        public string CastingDrawing { get; set; }
        public bool AcceptExtraPeices { get; set; }
        [Column("IsFAIRequire")]
        public bool IsFairequire { get; set; }
        [Column("ShipFAIAddressId")]
        public Guid? ShipFaiaddressId { get; set; }
        public Guid? ShippingAddress { get; set; }
        [MaxLength(250)]
        public byte[] ShippingAccountInfo { get; set; }
        [MaxLength(250)]
        public byte[] TruckingComapny { get; set; }
        [MaxLength(250)]
        public byte[] ShippingAccountNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DueDate { get; set; }
        public short ReleasedAbout { get; set; }
        public string Comment { get; set; }
        [Column("SendRFQTo")]
        public short SendRfqto { get; set; }
        public short Status { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [InverseProperty("Job")]
        public Customer Customer { get; set; }
        [ForeignKey("ModifiedBy")]
        [InverseProperty("Job")]
        public UserLogin ModifiedByNavigation { get; set; }
        [ForeignKey("ReleasedAbout")]
        [InverseProperty("Job")]
        public ReleasedAbout ReleasedAboutNavigation { get; set; }
        [ForeignKey("Status")]
        [InverseProperty("Job")]
        public Status StatusNavigation { get; set; }
        [InverseProperty("Quote")]
        public ICollection<Document> Document { get; set; }
        [InverseProperty("Job")]
        public ICollection<JobQuote> JobQuote { get; set; }
        [InverseProperty("Quote")]
        public ICollection<PartialShipment> PartialShipmentNavigation { get; set; }
    }
}

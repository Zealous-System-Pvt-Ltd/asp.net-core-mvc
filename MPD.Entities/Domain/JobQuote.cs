using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class JobQuote
    {
        public JobQuote()
        {
            AcceptedQuote = new HashSet<AcceptedQuote>();
            JobComment = new HashSet<JobComment>();
        }

        public Guid JobQuoteId { get; set; }
        public Guid MachinShopId { get; set; }
        public Guid JobId { get; set; }
        public short Status { get; set; }
        [StringLength(1000)]
        public string ReasonForNoQuote { get; set; }
        [StringLength(1000)]
        public string ReasonForRejected { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal CostperPeice { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ShippingCost { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal OtherCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDateRawMaterial { get; set; }
        public string Comments { get; set; }
        [Column("MPDCommissionType")]
        public short MpdcommissionType { get; set; }
        [Column("MPDCommission", TypeName = "decimal(10, 2)")]
        public decimal Mpdcommission { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }

        [ForeignKey("JobId")]
        [InverseProperty("JobQuote")]
        public Job Job { get; set; }
        [ForeignKey("MachinShopId")]
        [InverseProperty("JobQuote")]
        public MachineShop MachinShop { get; set; }
        [ForeignKey("MachinShopId")]
        [InverseProperty("JobQuote")]
        public UserLogin MachinShopNavigation { get; set; }
        [ForeignKey("Status")]
        [InverseProperty("JobQuote")]
        public Status StatusNavigation { get; set; }
        [InverseProperty("JobQuote")]
        public ICollection<AcceptedQuote> AcceptedQuote { get; set; }
        [InverseProperty("JobQuote")]
        public ICollection<JobComment> JobComment { get; set; }
    }
}

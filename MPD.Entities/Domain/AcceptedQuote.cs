using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class AcceptedQuote
    {
        public Guid AcceptedQuoteId { get; set; }
        public Guid JobQuoteId { get; set; }
        [Required]
        [Column("PONumber")]
        [StringLength(50)]
        public string Ponumber { get; set; }
        [Required]
        [Column("PODocument")]
        [StringLength(500)]
        public string Podocument { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("JobQuoteId")]
        [InverseProperty("AcceptedQuote")]
        public JobQuote JobQuote { get; set; }
    }
}

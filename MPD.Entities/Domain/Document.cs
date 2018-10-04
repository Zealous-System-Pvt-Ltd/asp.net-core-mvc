using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class Document
    {
        public Guid DocumentId { get; set; }
        public short DocumentType { get; set; }
        [Required]
        [StringLength(500)]
        public string DocumentName { get; set; }
        public Guid QuoteId { get; set; }

        [ForeignKey("DocumentType")]
        [InverseProperty("Document")]
        public DocumentType DocumentTypeNavigation { get; set; }
        [ForeignKey("QuoteId")]
        [InverseProperty("Document")]
        public Job Quote { get; set; }
    }
}

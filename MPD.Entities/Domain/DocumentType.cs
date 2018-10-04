using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Document = new HashSet<Document>();
        }

        public short DocumentTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [InverseProperty("DocumentTypeNavigation")]
        public ICollection<Document> Document { get; set; }
    }
}

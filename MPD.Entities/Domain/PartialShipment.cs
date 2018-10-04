using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class PartialShipment
    {
        public Guid PartialShipmentId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ReleaseDate { get; set; }
        public Guid QuoteId { get; set; }

        [ForeignKey("QuoteId")]
        [InverseProperty("PartialShipmentNavigation")]
        public Job Quote { get; set; }
    }
}

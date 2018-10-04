using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class CustomerContact
    {
        public Guid CustomerContactId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ContactId { get; set; }

        [ForeignKey("ContactId")]
        [InverseProperty("CustomerContact")]
        public Contact Contact { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("CustomerContact")]
        public Customer Customer { get; set; }
    }
}

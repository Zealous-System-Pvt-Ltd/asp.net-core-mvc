using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class MachineShopContact
    {
        public Guid MachineShopContactId { get; set; }
        public Guid MachinShopId { get; set; }
        public Guid ContactId { get; set; }

        [ForeignKey("ContactId")]
        [InverseProperty("MachineShopContact")]
        public Contact Contact { get; set; }
        [ForeignKey("MachinShopId")]
        [InverseProperty("MachineShopContact")]
        public MachineShop MachinShop { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPD.Entities.Domain
{
    public partial class JobComment
    {
        public Guid JobCommentId { get; set; }
        public Guid JobQuoteId { get; set; }
        [Required]
        public string Comment { get; set; }
        public Guid CommentBy { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CommentBy")]
        [InverseProperty("JobComment")]
        public UserLogin CommentByNavigation { get; set; }
        [ForeignKey("JobQuoteId")]
        [InverseProperty("JobComment")]
        public JobQuote JobQuote { get; set; }
    }
}

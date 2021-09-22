using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("PictureForReview")]
    public partial class PictureForReview
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        public Guid Review { get; set; }
        [StringLength(100)]
        public string Alt { get; set; }
        [Required]
        [StringLength(100)]
        public string Picture { get; set; }

        [ForeignKey(nameof(Review))]
        [InverseProperty("PictureForReviews")]
        public virtual Review ReviewNavigation { get; set; }
    }
}

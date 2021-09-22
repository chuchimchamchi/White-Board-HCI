using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("Reviewer")]
    public partial class Reviewer
    {
        public Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "decimal(11, 0)")]
        public decimal? PhoneNumber { get; set; }
        public Guid? BelongTo { get; set; }
        [StringLength(100)]
        public string Avatar { get; set; }
        [StringLength(100)]
        public string Certification { get; set; }

        [ForeignKey(nameof(BelongTo))]
        [InverseProperty(nameof(CampusMajor.Reviewers))]
        public virtual CampusMajor BelongToNavigation { get; set; }
        [InverseProperty(nameof(Review.CreatedByNavigation))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

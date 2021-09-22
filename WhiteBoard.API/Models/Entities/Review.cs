using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("Review")]
    public partial class Review
    {
        public Review()
        {
            PictureForReviews = new HashSet<PictureForReview>();
            ReviewCriteria = new HashSet<ReviewCriterion>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OnDateTime { get; set; }
        public Guid Campaign { get; set; }
        public Guid CreatedBy { get; set; }

        [ForeignKey(nameof(Campaign))]
        [InverseProperty("Reviews")]
        public virtual Campaign CampaignNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Reviewer.Reviews))]
        public virtual Reviewer CreatedByNavigation { get; set; }
        [InverseProperty(nameof(PictureForReview.ReviewNavigation))]
        public virtual ICollection<PictureForReview> PictureForReviews { get; set; }
        [InverseProperty(nameof(ReviewCriterion.ReviewNavigation))]
        public virtual ICollection<ReviewCriterion> ReviewCriteria { get; set; }
    }
}

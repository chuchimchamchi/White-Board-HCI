using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    public partial class ReviewCriterion
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        public Guid Review { get; set; }
        [Column("CampaignCriteriaID")]
        public Guid CampaignCriteriaId { get; set; }
        [StringLength(1000)]
        public string Comment { get; set; }
        public int? Rating { get; set; }

        [ForeignKey(nameof(CampaignCriteriaId))]
        [InverseProperty(nameof(CampaignCriterion.ReviewCriteria))]
        public virtual CampaignCriterion CampaignCriteria { get; set; }
        [ForeignKey(nameof(Review))]
        [InverseProperty("ReviewCriteria")]
        public virtual Review ReviewNavigation { get; set; }
    }
}

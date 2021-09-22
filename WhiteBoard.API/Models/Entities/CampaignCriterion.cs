using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    public partial class CampaignCriterion
    {
        public CampaignCriterion()
        {
            ReviewCriteria = new HashSet<ReviewCriterion>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("CampaignID")]
        public Guid CampaignId { get; set; }
        [Column("CriteriaID")]
        public Guid CriteriaId { get; set; }

        [ForeignKey(nameof(CampaignId))]
        [InverseProperty("CampaignCriteria")]
        public virtual Campaign Campaign { get; set; }
        [ForeignKey(nameof(CriteriaId))]
        [InverseProperty(nameof(Criterion.CampaignCriteria))]
        public virtual Criterion Criteria { get; set; }
        [InverseProperty(nameof(ReviewCriterion.CampaignCriteria))]
        public virtual ICollection<ReviewCriterion> ReviewCriteria { get; set; }
    }
}

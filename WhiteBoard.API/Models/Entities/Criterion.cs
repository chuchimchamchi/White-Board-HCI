using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    public partial class Criterion
    {
        public Criterion()
        {
            CampaignCriteria = new HashSet<CampaignCriterion>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column("GroupID")]
        public Guid? GroupId { get; set; }

        [ForeignKey(nameof(GroupId))]
        [InverseProperty(nameof(CriteriaGroup.Criteria))]
        public virtual CriteriaGroup Group { get; set; }
        [InverseProperty(nameof(CampaignCriterion.Criteria))]
        public virtual ICollection<CampaignCriterion> CampaignCriteria { get; set; }
    }
}

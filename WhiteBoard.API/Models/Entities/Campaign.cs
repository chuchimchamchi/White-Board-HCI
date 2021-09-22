using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("Campaign")]
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignCriteria = new HashSet<CampaignCriterion>();
            CampaignOns = new HashSet<CampaignOn>();
            Reviews = new HashSet<Review>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDay { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDay { get; set; }

        [InverseProperty(nameof(CampaignCriterion.Campaign))]
        public virtual ICollection<CampaignCriterion> CampaignCriteria { get; set; }
        [InverseProperty(nameof(CampaignOn.Campaign))]
        public virtual ICollection<CampaignOn> CampaignOns { get; set; }
        [InverseProperty(nameof(Review.CampaignNavigation))]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}

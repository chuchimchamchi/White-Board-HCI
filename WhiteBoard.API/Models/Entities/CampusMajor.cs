using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("CampusMajor")]
    public partial class CampusMajor
    {
        public CampusMajor()
        {
            CampaignOns = new HashSet<CampaignOn>();
            Reviewers = new HashSet<Reviewer>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("CampusID")]
        public Guid CampusId { get; set; }
        [Column("MajorID")]
        public Guid MajorId { get; set; }

        [ForeignKey(nameof(CampusId))]
        [InverseProperty("CampusMajors")]
        public virtual Campus Campus { get; set; }
        [ForeignKey(nameof(MajorId))]
        [InverseProperty("CampusMajors")]
        public virtual Major Major { get; set; }
        [InverseProperty(nameof(CampaignOn.CampusMajor))]
        public virtual ICollection<CampaignOn> CampaignOns { get; set; }
        [InverseProperty(nameof(Reviewer.BelongToNavigation))]
        public virtual ICollection<Reviewer> Reviewers { get; set; }
    }
}

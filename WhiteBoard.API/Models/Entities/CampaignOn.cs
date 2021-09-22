using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("CampaignOn")]
    public partial class CampaignOn
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("CampaignID")]
        public Guid CampaignId { get; set; }
        [Column("CampusMajorID")]
        public Guid CampusMajorId { get; set; }

        [ForeignKey(nameof(CampaignId))]
        [InverseProperty("CampaignOns")]
        public virtual Campaign Campaign { get; set; }
        [ForeignKey(nameof(CampusMajorId))]
        [InverseProperty("CampaignOns")]
        public virtual CampusMajor CampusMajor { get; set; }
    }
}

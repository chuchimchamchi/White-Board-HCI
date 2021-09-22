using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("CriteriaGroup")]
    public partial class CriteriaGroup
    {
        public CriteriaGroup()
        {
            Criteria = new HashSet<Criterion>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        [InverseProperty(nameof(Criterion.Group))]
        public virtual ICollection<Criterion> Criteria { get; set; }
    }
}

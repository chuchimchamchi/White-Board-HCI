using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("Major")]
    public partial class Major
    {
        public Major()
        {
            CampusMajors = new HashSet<CampusMajor>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        [InverseProperty(nameof(CampusMajor.Major))]
        public virtual ICollection<CampusMajor> CampusMajors { get; set; }
    }
}

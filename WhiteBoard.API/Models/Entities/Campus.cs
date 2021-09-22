using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("Campus")]
    public partial class Campus
    {
        public Campus()
        {
            CampusMajors = new HashSet<CampusMajor>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Address { get; set; }
        [Column(TypeName = "decimal(11, 0)")]
        public decimal? PhoneNumber { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [Column("UniversityID")]
        public Guid UniversityId { get; set; }

        [ForeignKey(nameof(UniversityId))]
        [InverseProperty("Campuses")]
        public virtual University University { get; set; }
        [InverseProperty(nameof(CampusMajor.Campus))]
        public virtual ICollection<CampusMajor> CampusMajors { get; set; }
    }
}

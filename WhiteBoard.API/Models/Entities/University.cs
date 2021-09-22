using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WhiteBoard_BE.Models.Entities
{
    [Table("University")]
    public partial class University
    {
        public University()
        {
            Campuses = new HashSet<Campus>();
        }

        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(11, 0)")]
        public decimal? PhoneNumber { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        [InverseProperty(nameof(Campus.University))]
        public virtual ICollection<Campus> Campuses { get; set; }
    }
}

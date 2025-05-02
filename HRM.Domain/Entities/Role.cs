using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    [Index("Name", Name = "UQ__Roles__737584F6E6D28474", IsUnique = true)]
    public partial class Role
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string? Description { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("Roles")]
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}

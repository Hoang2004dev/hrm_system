using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class Notification
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public int? CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("Notifications")]
        public virtual User? CreatedByNavigation { get; set; }
    }
}
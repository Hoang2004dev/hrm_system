using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class CalendarEvent
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EndTime { get; set; }

        public int CreatedBy { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        public bool? IsAllDay { get; set; }

        [StringLength(50)]
        public string? EventType { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("CalendarEvents")]
        public virtual User CreatedByNavigation { get; set; } = null!;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    [Index("Username", Name = "UQ__Users__536C85E450BE968E", IsUnique = true)]
    public partial class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Username { get; set; } = null!;

        [StringLength(255)]
        public string PasswordHash { get; set; } = null!;

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? FullName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? CreatedAt { get; set; }

        public bool? IsActive { get; set; }

        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        [InverseProperty("User")]
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        [InverseProperty("User")]
        public virtual ICollection<SystemLog> SystemLogs { get; set; } = new List<SystemLog>();

        [ForeignKey("UserId")]
        [InverseProperty("Users")]
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
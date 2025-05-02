using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    [Table("Attendance")]
    public partial class Attendance
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly? CheckInTime { get; set; }

        public TimeOnly? CheckOutTime { get; set; }

        [StringLength(255)]
        public string? Note { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Attendances")]
        public virtual Employee Employee { get; set; } = null!;
    }
}
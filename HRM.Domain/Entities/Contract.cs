using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class Contract
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [StringLength(50)]
        public string? ContractType { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Salary { get; set; }

        [StringLength(255)]
        public string? Note { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Contracts")]
        public virtual Employee Employee { get; set; } = null!;
    }
}
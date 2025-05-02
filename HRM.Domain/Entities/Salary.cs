using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class Salary
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BaseSalary { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Bonus { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Allowance { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("Salaries")]
        public virtual Employee Employee { get; set; } = null!;
    }
}
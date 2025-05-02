using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class Position
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; } = null!;

        [StringLength(50)]
        public string? Level { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [InverseProperty("FromPosition")]
        public virtual ICollection<EmployeeTransfer> EmployeeTransferFromPositions { get; set; } = new List<EmployeeTransfer>();

        [InverseProperty("ToPosition")]
        public virtual ICollection<EmployeeTransfer> EmployeeTransferToPositions { get; set; } = new List<EmployeeTransfer>();

        [InverseProperty("Position")]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}

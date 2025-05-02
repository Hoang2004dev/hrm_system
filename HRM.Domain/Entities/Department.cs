using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HRM.Domain.Entities
{
    public partial class Department
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string? Description { get; set; }

        [InverseProperty("FromDepartment")]
        public virtual ICollection<EmployeeTransfer> EmployeeTransferFromDepartments { get; set; } = new List<EmployeeTransfer>();

        [InverseProperty("ToDepartment")]
        public virtual ICollection<EmployeeTransfer> EmployeeTransferToDepartments { get; set; } = new List<EmployeeTransfer>();

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
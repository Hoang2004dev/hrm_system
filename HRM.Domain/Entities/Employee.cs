using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.Domain.Entities
{
    public partial class Employee
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        public DateOnly HireDate { get; set; }

        public int? DepartmentId { get; set; }

        public int? PositionId { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

        [InverseProperty("Employee")]
        public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

        [ForeignKey("DepartmentId")]
        [InverseProperty("Employees")]
        public virtual Department? Department { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeTransfer> EmployeeTransfers { get; set; } = new List<EmployeeTransfer>();

        [InverseProperty("Employee")]
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        [ForeignKey("PositionId")]
        [InverseProperty("Employees")]
        public virtual Position? Position { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
    }

}
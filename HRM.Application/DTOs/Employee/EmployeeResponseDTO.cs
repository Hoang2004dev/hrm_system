using HRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.DTOs.Employee
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public DateOnly HireDate { get; set; }

        public int? DepartmentId { get; set; }

        public int? PositionId { get; set; }
    }
}

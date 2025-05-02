using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.DTOs.Employee
{
    public class EmployeeCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateOnly HireDate { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }
}

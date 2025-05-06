using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.DTOs.Department
{
    public class DepartmentCreateDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}

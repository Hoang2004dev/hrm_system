using HRM.Application.DTOs.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Department.Commands
{
    public class CreateDepartmentCommand : IRequest<DepartmentResponseDTO>
    {
        public DepartmentCreateDTO DepartmentDto { get; }

        public CreateDepartmentCommand(DepartmentCreateDTO departmentDto)
        {
            DepartmentDto = departmentDto;
        }
    }
}

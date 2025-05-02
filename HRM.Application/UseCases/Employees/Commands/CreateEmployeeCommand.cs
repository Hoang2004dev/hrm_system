using HRM.Application.DTOs.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Employees.Commands
{
    public record CreateEmployeeCommand(
        string FullName,
        string Email,
        string? Phone,
        string? Address,
        DateOnly? DateOfBirth,
        string? Gender,
        DateOnly HireDate,
        int DepartmentId,
        int PositionId
    ) : IRequest<EmployeeCreateDto>;
}


using HRM.Application.DTOs;
using HRM.Application.DTOs.Employee;
using MediatR;
using System.Collections.Generic;

namespace HRM.Application.UseCases.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeResponseDTO>>
    {
    }
}

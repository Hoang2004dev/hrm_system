using HRM.Application.DTOs.Employee;
using HRM.Application.UseCases.Employees.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeCreateDto> CreateEmployeeAsync(CreateEmployeeCommand command);
    }

}

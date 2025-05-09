using HRM.Domain.Entities;
using AutoMapper;
using MediatR;
using FluentValidation;
using HRM.Application.DTOs.Employee;
using HRM.Application.UseCases.Employees.Validators;
using HRM.Application.Interfaces.Repositories;

namespace HRM.Application.UseCases.Employees.Commands
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeCreateDto>
    {
        private readonly CreateEmployeeValidator _validator;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(CreateEmployeeValidator validator,IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _validator = validator;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeCreateDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            // Validate Command
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var employee = _mapper.Map<Employee>(request);

            await _employeeRepository.AddAsync(employee);
            return _mapper.Map<EmployeeCreateDto>(employee);
        }

    }
}

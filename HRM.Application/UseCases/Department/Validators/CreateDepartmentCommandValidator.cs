using FluentValidation;
using HRM.Application.UseCases.Department.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.UseCases.Department.Validators
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.DepartmentDto.Name)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(100).WithMessage("Department name must not exceed 100 characters.");

            RuleFor(x => x.DepartmentDto.Description)
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");
        }
    }
}

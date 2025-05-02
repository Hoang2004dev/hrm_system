using FluentValidation;
using HRM.Application.UseCases.Employees.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(x => x.Phone).MaximumLength(20);
            RuleFor(x => x.Address).MaximumLength(255);
            RuleFor(x => x.Gender).Must(g => g == "Male" || g == "Female" || g == null)
                .WithMessage("Gender must be 'Male', 'Female', or null");
            RuleFor(x => x.HireDate).NotEmpty();
            RuleFor(x => x.DepartmentId).GreaterThan(0);
            RuleFor(x => x.PositionId).GreaterThan(0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using FluentValidation;

namespace DataLayer.ModelsValidation
{
    public class EmployeeValidation:AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Address).Length(0, 60);
            RuleFor(x => x.BirthDate).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FirstName).NotNull().Length(2, 30);
            RuleFor(x => x.LastName).NotNull().Length(2, 30);

        }
    }
}

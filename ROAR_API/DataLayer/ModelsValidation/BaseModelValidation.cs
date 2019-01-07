using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using FluentValidation;

namespace DataLayer.ModelsValidation
{
    public class BaseModelValidation:AbstractValidator<BaseModel>
    {
        public BaseModelValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CreationDate).NotNull();
            
            
        }
    }
}

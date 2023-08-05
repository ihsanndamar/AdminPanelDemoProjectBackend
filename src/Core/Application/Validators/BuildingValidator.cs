using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class BuildingValidator : AbstractValidator<Building>
    {
        public BuildingValidator()
        {
            RuleFor(b => b.BuildingCost).GreaterThan(0).WithMessage("Building cost must be greater than 0");
            RuleFor(b => b.BuildingType).NotEmpty().WithMessage("Building type must not be empty");
            RuleFor(b => b.ConstructionTime).GreaterThan(30).WithMessage("Construction time must be greater than 30 seconds").LessThan(1800).WithMessage("Construction time must be less than 1800");
        }
    }
}

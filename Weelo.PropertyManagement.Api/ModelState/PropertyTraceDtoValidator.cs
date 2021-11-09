using FluentValidation;
using System;
using Weelo.PropertyManagement.Aplication.Dtos;

namespace Weelo.PropertyManagement.Api.ModelState
{
    public class PropertyTraceDtoValidator : AbstractValidator<PropertyTraceDto>
    {
        public PropertyTraceDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(150);
            RuleFor(p => p.OwnerDocument).NotEmpty().MinimumLength(4);
            RuleFor(p => p.Address).NotEmpty().MaximumLength(200);
            RuleFor(p => p.CodeInternal).NotEmpty().MaximumLength(300);
            RuleFor(p => p.Price).NotEmpty().NotEqual(0);
            RuleFor(p => p.Year).NotEmpty().NotEqual(0).Must(ValidateYear);
        }

        public bool ValidateYear(int year)
        {
            bool result = DateTime.TryParse(string.Format("1/1/{0}", year), out _);
            return result;
        }
    }
}

using FluentValidation;
using Weelo.PropertyManagement.Aplication.Dtos;

namespace Weelo.PropertyManagement.Api.ModelState
{
    public class PriceDtoValidator : AbstractValidator<PriceDto>
    {
        public PriceDtoValidator()
        {
            RuleFor(o => o.InernalCode).NotEmpty();
            RuleFor(o => o.Price).NotEmpty().NotEqual(0);
        }
    }
}

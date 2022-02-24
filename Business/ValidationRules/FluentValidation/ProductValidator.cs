using Entities.Concrete;

using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithErrorCode("2020");
            RuleFor(p => p.Description).NotEmpty().WithErrorCode("2021");
            RuleFor(p => (int)p.UnitId).GreaterThanOrEqualTo(1);
        }
    }
}

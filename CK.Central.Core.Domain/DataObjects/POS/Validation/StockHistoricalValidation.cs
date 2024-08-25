using CK.Central.Core.Domain.DataObjects.POS.Entity;
using FluentValidation;

namespace CK.Central.Core.Domain.DataObjects.POS.Validation
{
    public class StockHistoricalValidation : AbstractValidator<StockHistoricalEntity>
    {
        public StockHistoricalValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("");

            RuleFor(x => x.IsDeleted)
                .NotNull().WithMessage("");

            RuleFor(x => x.CreatedBy)
                .NotNull().WithMessage("");

            RuleFor(x => x.CreatedDatetime)
                .NotNull().WithMessage("");
        }
    }
}

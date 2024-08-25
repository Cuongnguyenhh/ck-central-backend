using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using FluentValidation;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Validation
{
    public class OrderServiceValidation : AbstractValidator<OrderServiceEntity>
    {
        public OrderServiceValidation()
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

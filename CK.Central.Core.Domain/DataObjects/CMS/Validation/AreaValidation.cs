using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Validation
{
    public class AreaValidation : AbstractValidator<AreaEntity>
    {
        public AreaValidation()
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

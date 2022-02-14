using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class DuesValidator : AbstractValidator<Dues>
    {
        public DuesValidator()
        {
            RuleFor(d => d.Amount).NotEmpty();
        }
    }
}

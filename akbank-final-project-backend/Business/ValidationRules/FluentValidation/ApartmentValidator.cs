using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ApartmentValidator : AbstractValidator<Apartment>
    {
        public ApartmentValidator()
        {

            RuleFor(a => a.DuesId).NotEmpty();
            RuleFor(a => a.OwnerId).NotEmpty();
            RuleFor(a => a.ResidentType).NotEmpty();
            RuleFor(a => a.BlockNo).NotEmpty();
            RuleFor(a => a.FloorNo).NotEmpty();
            RuleFor(a => a.DoorNo).NotEmpty();
            RuleFor(a => a.ApartmentType).NotEmpty();
            
           
  
        }
    }
}

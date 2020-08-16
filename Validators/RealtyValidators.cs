using FluentValidation;
using FluentValidation.Validators;
using RealEstateManagement.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateManagement.Validators
{
    public class RealtyValidators : AbstractValidator<RealtyFirm>
    {
        public RealtyValidators()
        {
            RuleFor(r => r.RealtyName).NotEmpty();
            RuleFor(r => r.RealtyAddress).NotEmpty();
            RuleFor(r => r.RealtyContact).NotEmpty();
            RuleFor(r => r.RealtyEmail).NotEmpty();
            RuleFor(r => r.RealtyMobile).NotEmpty();
            

        }
    }
}

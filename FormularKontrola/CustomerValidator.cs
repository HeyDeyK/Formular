using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FormularKontrola
{
    class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Surname).NotEmpty().WithMessage("Příjmení není vyplňěné");
            RuleFor(customer => customer.Forename).NotEmpty().WithMessage("Křestní jméno není vyplňené");
            RuleFor(customer => customer.Age).Must(IsThisNumber).WithMessage("Věk není validní");
            RuleFor(customer => customer.Address).Length(20, 250);
        }
        private bool IsThisNumber(string Age)
        {
            var isNumeric = int.TryParse(Age, out int n);
            return isNumeric;
        }
    }

    
}


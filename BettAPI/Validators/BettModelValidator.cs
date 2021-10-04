using BettAPI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettAPI.Validators
{
    public class BettModelValidator:AbstractValidator<BettModel>
    {
        public BettModelValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().GreaterThan(0).WithMessage("Amount should be more than 0");
            RuleFor(x => x.Odds).NotNull().NotEmpty();
            RuleFor(x => x.Type).NotEmpty().Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.isUpdated).NotEmpty().WithMessage("You are updating the bet so you can't change the True value");
            RuleFor(x => x.UpdatedTime).NotNull().GreaterThanOrEqualTo(DateTime.Now).WithMessage("Past dates are not allowed");
        }
    }
}

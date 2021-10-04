using BettAPI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettAPI.Validators
{
    public class UpdatedBettModelValidator:AbstractValidator<UpdatedBettModel>
    {
        public UpdatedBettModelValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Odds).NotEmpty();
            RuleFor(x => x.Type).NotEmpty().Matches("^[a-zA-Z0-9 ]*$"); ;
        }

    }
}

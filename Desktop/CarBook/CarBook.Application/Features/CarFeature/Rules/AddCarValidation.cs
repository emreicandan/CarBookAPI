using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CarFeature.Commands;
using FluentValidation;

namespace CarBook.Application.Features.CarFeature.Rules;

    public class AddCarValidation : AbstractValidator<AddCarCommand>
    {
        public AddCarValidation(){
            RuleFor(c => c.Fuel).NotEmpty().WithMessage("BrandId must not be empty");
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CarFeature.Commands;
using FluentValidation;

namespace CarBook.Application.Features.CarFeature.Rules;

    public class UpdateCarValidator:AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarValidator(){

            RuleFor(c => c.Km).NotEmpty().WithMessage("Car km must not be empty");
            
        }
    }

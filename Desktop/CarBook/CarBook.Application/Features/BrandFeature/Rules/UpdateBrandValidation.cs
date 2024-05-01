using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.BrandFeature.Commands;
using FluentValidation;

namespace CarBook.Application.Features.BrandFeature.Rules;

public class UpdateBrandValidation : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandValidation()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage("Brand name must not be empty!");
        RuleFor(b => b.Name).MinimumLength(3).WithMessage("The name field can consist of at least 3 characters!");
    }
}
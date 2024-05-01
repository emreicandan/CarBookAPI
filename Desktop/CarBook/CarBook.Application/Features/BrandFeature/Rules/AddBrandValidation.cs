using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.BrandFeature.Commands;
using FluentValidation;


namespace CarBook.Application.Features.BrandFeature.Rules;

public class AddBrandValidation : AbstractValidator<AddBrandCommand>{

	public AddBrandValidation(){
		RuleFor(b=>b.Name).NotEmpty().WithMessage("Brand must not be empty!");
		RuleFor(b=>b.Name).MinimumLength(3).WithMessage("Bclerand name cannot be less than 3 characters");
	}
}
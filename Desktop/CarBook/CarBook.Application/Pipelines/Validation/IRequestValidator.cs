using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;


namespace CarBook.Application.Pipelines.Validation;

public interface IRequestValidator
{
    public IEnumerable<IValidator> Validators { get; set; }
}
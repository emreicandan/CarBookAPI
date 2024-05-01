using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.BrandFeature.Commands.Queries.DTOs;
using CarBook.Application.Features.BrandFeature.DTOs;
using CarBook.Application.Features.BrandFeature.Rules;
using CarBook.Application.Pipelines.Validation;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook.Application.Features.BrandFeature.Commands;

    public class AddBrandCommand:IRequest<AddedBrandDto>,IRequestValidator
    {
    public string Name { get; set; }
    
    [JsonIgnore]
    public IEnumerable<IValidator> Validators { get ;set ; } = [new AddBrandValidation()];

    public class Handler(IBrandRepository brandRepository, IMapper mapper) : IRequestHandler<AddBrandCommand, AddedBrandDto>
    {
        public async Task<AddedBrandDto> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = mapper.Map<Brand>(request);
            var addedBrand = await brandRepository.AddAsync(brand);

            return mapper.Map<AddedBrandDto>(addedBrand);
        }
    }
}

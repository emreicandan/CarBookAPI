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
using CarBook.Application.Utilities;
using CarBook.Domain.Entities;
using FluentValidation;
using MediatR;

namespace CarBook.Application.Features.BrandFeature.Commands
{
    public class UpdateBrandCommand:IRequest<UpdatedBrandDto> , IRequestValidator
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<IValidator> Validators{ get; set; } = [new UpdateBrandValidation()];
        public class Handler(IBrandRepository brandRepository, IMapper mapper) : IRequestHandler<UpdateBrandCommand, UpdatedBrandDto>
        {
            public async Task<UpdatedBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = mapper.Map<Brand>( await brandRepository.GetAsync(b=> b.Id == request.Id)).MapWithSource(request);
                var updatedBrand = await brandRepository.UpdateAsync(brand);

                return mapper.Map<UpdatedBrandDto>(updatedBrand);
            }
        }

    }
}
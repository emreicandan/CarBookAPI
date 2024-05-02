using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.FatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FatureFeature.Commands;

    public class AddFeatureCommand:IRequest<AddedFeatureDto>
    {
        public string Name { get; set; }

    public class Handler(IFeatureRepository featureRepository, IMapper mapper) : IRequestHandler<AddFeatureCommand, AddedFeatureDto>
    {
        public async Task<AddedFeatureDto> Handle(AddFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = mapper.Map<Feature>(request);

            var addedFeature = await featureRepository.AddAsync(feature);

            return mapper.Map<AddedFeatureDto>(addedFeature);
        }
    }
}


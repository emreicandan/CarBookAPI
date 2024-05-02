using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.FatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FatureFeature.Commands
{
    public class UpdateFeatureCommand:IRequest<UpdatedFeatureDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public class Handler(IFeatureRepository featureRepository, IMapper mapper) : IRequestHandler<UpdateFeatureCommand, UpdatedFeatureDto>
        {
            public async Task<UpdatedFeatureDto> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
            {
                var feature = mapper.Map<Feature>(await featureRepository.GetAsync(f=> f.Id == request.Id));

                var updatedFeature = await featureRepository.UpdateAsync(feature);

                return mapper.Map<UpdatedFeatureDto>(updatedFeature);
            }
        }
    }
}
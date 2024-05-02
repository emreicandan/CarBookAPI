using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.FatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FatureFeature.Queries
{
    public class FeatureGetByIdQuery(int id):IRequest<FeatureGetByIdDto>
    {
        public int Id { get; set; } = id;

        public class Handler(IFeatureRepository featureRepository, IMapper mapper) : IRequestHandler<FeatureGetByIdQuery, FeatureGetByIdDto>
        {
            public async Task<FeatureGetByIdDto> Handle(FeatureGetByIdQuery request, CancellationToken cancellationToken)
            {
                var feature = mapper.Map<Feature>( await featureRepository.GetAsync(f=> f.Id == request.Id));

                return mapper.Map<FeatureGetByIdDto>( feature );
            }
        }

    }
}
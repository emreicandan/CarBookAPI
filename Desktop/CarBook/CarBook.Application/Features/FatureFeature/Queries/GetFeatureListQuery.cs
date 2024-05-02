using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.FatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FatureFeature.Queries
{
    public class GetFeatureListQuery:IRequest<IList<GetFeatureListDto>>
    {
        public class Handler(IFeatureRepository featureRepository, IMapper mapper) : IRequestHandler<GetFeatureListQuery, IList<GetFeatureListDto>>
        {
            public async Task<IList<GetFeatureListDto>> Handle(GetFeatureListQuery request, CancellationToken cancellationToken)
            {
                var features = await featureRepository.GetAllAsync();

                return features.Select(f=> mapper.Map<GetFeatureListDto>(f)).ToList();
            }
        }
    }
}
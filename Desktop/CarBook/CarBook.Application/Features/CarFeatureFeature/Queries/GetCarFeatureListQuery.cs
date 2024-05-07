using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.CarFeatureFeature.Queries;
    public class GetCarFeatureListQuery:IRequest<IList<GetCarFeatureListDto>>
    {
    public class Handler(ICarFeatureRepository carFeatureRepository, IMapper mapper) : IRequestHandler<GetCarFeatureListQuery, IList<GetCarFeatureListDto>>
    {
        public async Task<IList<GetCarFeatureListDto>> Handle(GetCarFeatureListQuery request, CancellationToken cancellationToken)
        {
            var carFeatures = await carFeatureRepository.GetAllAsync();

            return carFeatures.Select(cf => mapper.Map<GetCarFeatureListDto>(cf)).ToList();
        }
    }
}

    public class CarFeatureGetByIdQuery(int id):IRequest<CarFeatureGetByIdDto>
    {
        public int Id { get; set;} = id;

    public class Handler(ICarFeatureRepository carFeatureRepository, IMapper mapper) : IRequestHandler<CarFeatureGetByIdQuery, CarFeatureGetByIdDto>
    {
        public async Task<CarFeatureGetByIdDto> Handle(CarFeatureGetByIdQuery request, CancellationToken cancellationToken)
        {
            var carFeature = mapper.Map<Domain.Entities.CarFeature>( await carFeatureRepository.GetAsync(cf => cf.Id == request.Id));

            return mapper.Map<CarFeatureGetByIdDto>(carFeature);   
        }
    }
}

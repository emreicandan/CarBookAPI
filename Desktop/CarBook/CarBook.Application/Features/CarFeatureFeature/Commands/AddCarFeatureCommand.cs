using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.CarFeatureFeature.Commands;

public class AddCarFeatureCommand:IRequest<AddedCarFeatureDto>
    {
    public int CarId { get; set; }

    public int FeatureId { get; set; }

    public bool Available { get; set; }

    public class Handler(ICarFeatureRepository carFeatureRepository, IMapper mapper) : IRequestHandler<AddCarFeatureCommand, AddedCarFeatureDto>
    {
        public async Task<AddedCarFeatureDto> Handle(AddCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeature = mapper.Map<CarBook.Domain.Entities.CarFeature>(request);

            var addedCarFeature = await carFeatureRepository.AddAsync(carFeature);

            return mapper.Map<AddedCarFeatureDto>(addedCarFeature);
        }
    }
}

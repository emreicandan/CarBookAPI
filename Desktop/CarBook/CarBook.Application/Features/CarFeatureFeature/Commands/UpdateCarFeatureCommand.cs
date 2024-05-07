using AutoMapper;
using CarBook.Application.Features.CarFeatureFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Application.Utilities;
using MediatR;

namespace CarBook.Application.Features.CarFeatureFeature.Commands;

public class UpdateCarFeatureCommand:IRequest<UpdatedCarFeatureDto>
    {
    public int Id { get; set; }
    public int CarId { get; set; }

    public int FeatureId { get; set; }

    public bool Available { get; set; }

    public class Handler(ICarFeatureRepository carFeatureRepository, IMapper mapper) : IRequestHandler<UpdateCarFeatureCommand, UpdatedCarFeatureDto>
    {
        public async Task<UpdatedCarFeatureDto> Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeature = mapper.Map<CarBook.Domain.Entities.CarFeature>(request).MapWithSource(request);

            var updatedCarFeature = await carFeatureRepository.UpdateAsync(carFeature);

            return mapper.Map<UpdatedCarFeatureDto>(updatedCarFeature);
        }
    }
}

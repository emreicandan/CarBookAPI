using AutoMapper;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.CarFeatureFeature.Commands;

public class DeleteCarFeatureCommand(int id) : IRequest<bool>
    {
        public int Id { get; set; } = id;

    public class Handler(ICarFeatureRepository carFeatureRepository, IMapper mapper) : IRequestHandler<DeleteCarFeatureCommand, bool>
    {
        public async Task<bool> Handle(DeleteCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeature = mapper.Map<Domain.Entities.CarFeature>(await carFeatureRepository.GetAsync(cf => cf.Id == request.Id));

            await carFeatureRepository.DeleteAsync(carFeature);

            return  true;
        }
    }
}
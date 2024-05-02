using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FatureFeature.Commands
{
    public class DeleteFeatureCommand(int id):IRequest<bool>
    {
        public int Id { get; set; } = id;

        public class Handler(IFeatureRepository featureRepository, IMapper mapper) : IRequestHandler<DeleteFeatureCommand, bool>
        {
            public async Task<bool> Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
            {
                var feature = mapper.Map<Feature>(await featureRepository.GetAsync(f=> f.Id == request.Id));
                await featureRepository.DeleteAsync(feature);

                return true;
            }
        }
    }
}
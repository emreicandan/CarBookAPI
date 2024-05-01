using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.BrandFeature.Commands
{
    public class DeleteBrandCommand(int id):IRequest<bool>
    {
        public int Id { get; set; } = id;

        public class Handler(IBrandRepository brandRepository) : IRequestHandler<DeleteBrandCommand, bool>
        {
            public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brand = await brandRepository.GetAsync(b => b.Id == request.Id );

                await brandRepository.DeleteAsync(brand);

                return true;
            }
        }
    }
}
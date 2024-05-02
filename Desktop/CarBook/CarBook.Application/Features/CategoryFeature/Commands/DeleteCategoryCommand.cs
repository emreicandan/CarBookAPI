using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CategoryFeature.Commands;

    public class DeleteCategoryCommand(int id):IRequest<bool>
    {
        public int Id { get; set; } = id;

    public class Handler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<DeleteCategoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(categoryRepository.GetAsync(c=>c.Id==request.Id));

            await categoryRepository.DeleteAsync(category);

            return true;
        }
    }
}

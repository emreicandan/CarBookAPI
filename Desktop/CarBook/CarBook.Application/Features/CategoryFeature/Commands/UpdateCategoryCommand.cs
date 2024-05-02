using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CategoryFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Application.Utilities;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.CategoryFeature.Commands;

    public class UpdateCategoryCommand:IRequest<UpdatedCategoryDto>
    {
    public int Id { get; set; } 

    public string Name { get; set;}

    public class Handler(ICategoryRepository categoryRepository, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
    {
        public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(await categoryRepository.GetAsync(c => c.Id == request.Id)).MapWithSource(request);

            var updatedCategory = await categoryRepository.UpdateAsync(category);

            return mapper.Map<UpdatedCategoryDto>(updatedCategory);
        }
    }
}

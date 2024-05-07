using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.CarFeatureFeature.DTOs;
using CarBook.Application.Features.CarPaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using MediatR;

namespace CarBook.Application.Features.CarPaymentFeature.Queries;
public class GetCarPaymentListQuery:IRequest<IList<GetCarPaymentListDto>>
    {
    public class Handler(ICarPaymentRepository carPaymentRepository, IMapper mapper) : IRequestHandler<GetCarPaymentListQuery, IList<GetCarPaymentListDto>>
    {
        public async Task<IList<GetCarPaymentListDto>> Handle(GetCarPaymentListQuery request, CancellationToken cancellationToken)
        {
           var carPayments = await carPaymentRepository.GetAllAsync();

           return carPayments.Select(cp => mapper.Map<GetCarPaymentListDto>(cp)).ToList();
        }
    }
}

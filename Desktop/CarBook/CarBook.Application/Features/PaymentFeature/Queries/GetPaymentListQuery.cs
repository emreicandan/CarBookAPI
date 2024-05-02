using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarBook.Application.Features.PaymentFeature.DTOs;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PaymentFeature.Queries;

public class GetPaymentListQuery : IRequest<IList<GetPaymentListDto>>
    {
    public class Handler(IPaymentRepository paymentRepository, IMapper mapper) : IRequestHandler<GetPaymentListQuery, IList<GetPaymentListDto>>
    {
        public async Task<IList<GetPaymentListDto>> Handle(GetPaymentListQuery request, CancellationToken cancellationToken)
        {
           var payments=await paymentRepository.GetAllAsync();

           return payments.Select(p => mapper.Map<GetPaymentListDto>(p)).ToList();
        }
    }
}

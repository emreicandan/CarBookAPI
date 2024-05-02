using CarBook.Domain.Entities;

namespace CarBook.Application.Features.PaymentFeature.DTOs;

public class GetPaymentListDto
    {
    public int Id { get; set; }
    public string PlanName { get; set; }

    public List<CarPayment> CarPayments { get; set; }
    }

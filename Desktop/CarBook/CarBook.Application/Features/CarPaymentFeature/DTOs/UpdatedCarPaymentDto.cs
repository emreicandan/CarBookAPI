using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarPaymentFeature.DTOs;

public class UpdatedCarPaymentDto
    {
    public int CarId { get; set; }

    public int PaymentId { get; set; }

    public Car Car { get; set; }

    public Payment Payment { get; set; }

    public decimal Price { get; set; }

    }

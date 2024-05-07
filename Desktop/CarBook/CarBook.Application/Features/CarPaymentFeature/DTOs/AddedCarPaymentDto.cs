using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CarPaymentFeature.DTOs;

public class AddedCarPaymentDto
    {
    public int CarId { get; set; }

    public int PaymentId { get; set; }

    public Car Car { get; set; }

    public Payment Payment { get; set; }

    public decimal Price { get; set; }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class CarPayment:Entity<int>
{
    public int CarId { get; set; }

    public int PaymentId { get; set; }

    public Car Car { get; set; }

    public Payment Payment { get; set; }

    public decimal Price { get; set; }
}
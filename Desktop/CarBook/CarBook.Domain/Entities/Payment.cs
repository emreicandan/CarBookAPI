using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Payment:Entity<int>
{
    public string PlanName { get; set; }

    public List<CarPayment> CarPayments { get; set; }
}
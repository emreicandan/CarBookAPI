using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities;

public class Contact:Entity<int>
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Subject { get; set; }

    public string Message { get; set; }

    public DateTime CreatedDate { get; set; }
}
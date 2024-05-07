using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace CarBook.Domain.Entities;


public class User:Entity<int>
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }

    public Role Role {get ; set;}
}
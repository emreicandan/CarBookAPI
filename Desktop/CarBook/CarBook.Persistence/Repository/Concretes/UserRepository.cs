using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Repository.Services;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repository.Concretes;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(CarBookDbContext _context) : base(_context)
    {
    }
}

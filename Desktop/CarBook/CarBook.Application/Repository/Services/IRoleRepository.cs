using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Repository.Services;

    public interface IRoleRepository:IRepository<Role>,IAsyncRepository<Role>
    {
        
    }

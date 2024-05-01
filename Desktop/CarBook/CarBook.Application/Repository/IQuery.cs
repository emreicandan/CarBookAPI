using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain;

namespace CarBook.Application.Repository;

    public interface IQuery<TEntity>
    where TEntity : Entity
    {
        IQueryable<TEntity> Query();
    }

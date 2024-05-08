using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.UserFeature.DTOs;

namespace CarBook.Application.Utilities.Security;

    public interface ITokenHelper<T>
    {
        public T CreateToken(GetCheckUserDto result);
    }

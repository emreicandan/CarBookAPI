using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Application.Features.UserFeature.DTOs;

    public class GetCheckUserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Role {get; set; }

        public bool IsExist { get; set; }
    }

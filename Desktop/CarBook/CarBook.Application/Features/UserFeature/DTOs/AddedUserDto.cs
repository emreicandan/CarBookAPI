using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.UserFeature.DTOs
{
    public class AddedUserDto
    {
        public string UserName { get; set; }

        public int RoleId { get; set; }

        public Role Role{ get; set; }
    }
}
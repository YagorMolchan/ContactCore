using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Models.ViewModels
{
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<IdentityRole> AllRoles { get; set; }

        public List<string> UserRoles { get; set; }
    }
}

using ContactCore.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Interfaces
{
    public interface IUserRepository
    {
        List<ApplicationUser> Users { get; }

        ApplicationUser GetUser(string id);
        
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Interfaces
{
    public interface IRoleRepository
    {
        List<IdentityRole> Roles { get; }
    }
}

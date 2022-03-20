using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Models.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }
        
    }
}

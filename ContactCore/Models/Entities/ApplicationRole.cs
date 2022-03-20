using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Models.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

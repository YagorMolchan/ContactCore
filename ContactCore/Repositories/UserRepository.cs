using ContactCore.Data;
using ContactCore.Interfaces;
using ContactCore.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ApplicationUser> Users { get => _dbContext.Users.ToList(); }

        public ApplicationUser GetUser(string id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

    }
}

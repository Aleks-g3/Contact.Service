using Contact.Service.Core.Models;
using Contact.Service.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Context.Repositories
{
    public class UserRepoitory : IUserRepository
    {
        private readonly ContactDbContext context;

        public UserRepoitory(ContactDbContext context)
        {
            this.context = context;
        }

        public Task<int> AddAsync(User user)
        {
           context.Users.Add(user);
            return context.SaveChangesAsync();
        }

        public Task<User> GetUserByEmail(string email)
        {
            return context.Users.FirstAsync(u=>u.Email==email);
        }
    }
}

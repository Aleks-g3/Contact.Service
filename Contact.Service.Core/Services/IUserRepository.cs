using Contact.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Core.Services
{
    public interface IUserRepository
    {
        Task<int> AddAsync(User user);
        Task<User> GetUserByEmail(string email); 
    }
}

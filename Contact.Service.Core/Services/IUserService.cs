using Contact.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Core.Services
{
    public interface IUserService
    {
        Task<int> RegisterAsync(User user, string password);
        Task<string> LoginAsync(LoginUser userDTO);
    }
}

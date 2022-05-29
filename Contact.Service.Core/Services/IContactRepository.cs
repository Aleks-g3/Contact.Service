using Contact.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Core.Services
{
    public interface IContactRepository
    {
        Task<int> AddAsync(ContactEntity contact);
        Task UpdateAsync(ContactEntity contact);
        Task DeleteAsync(int id);
        Task<ContactEntity> GetByIdAsync(int id);
        Task<IEnumerable<ContactEntity>> GetAllAsync();
    }
}

using Contact.Service.Core.Models;
using Contact.Service.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Context.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public Task<int> AddAsync(ContactEntity contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ContactEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ContactEntity contact)
        {
            throw new NotImplementedException();
        }
    }
}

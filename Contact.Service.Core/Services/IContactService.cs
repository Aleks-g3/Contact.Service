using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Service.Core.Models;

namespace Contact.Service.Core.Services
{
    public interface IContactService
    {
        Task<int> AddAsync(ContactEntity contact);
        Task UpdateAsync(int contactId, ContactEntity contact);
        Task DeleteAsync(int contactId);
    }
}

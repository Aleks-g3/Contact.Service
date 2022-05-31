using Contact.Service.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Task<int> AddAsync(ContactEntity contact)
        {
            return contactRepository.AddAsync(contact);
        }

        public async Task DeleteAsync(int contactId)
        {
            var contact = await contactRepository.GetByIdAsync(contactId);

            await contactRepository.DeleteAsync(contact);
        }

        public async Task UpdateAsync(int contactId, ContactEntity updateContact)
        {
            var contact = await contactRepository.GetByIdAsync(contactId);

            contact.Update(updateContact);

            await contactRepository.UpdateAsync(contact);
        }
    }
}

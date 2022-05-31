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
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext context;

        public ContactRepository(ContactDbContext context)
        {
            this.context = context;
        }

        public Task<int> AddAsync(ContactEntity contact)
        {
            context.Contacts.Add(contact);
            return context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContactEntity contact)
        {
            context.Contacts.Remove(contact);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactEntity>> GetAllAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public Task<ContactEntity> GetByIdAsync(int id)
        {
            return context.Contacts.FirstAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(ContactEntity contact)
        {
            context.Contacts.Update(contact);
            await context.SaveChangesAsync();
        }
    }
}

using Contact.Service.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Service.Context
{
    public class ContactDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.Property(p => p.Email).IsRequired();
                e.Property(p=>p.HashPassword).IsRequired();
            });

            builder.Entity<ContactEntity>(e =>
            {
                e.Property(p => p.Name).IsRequired();
                e.Property(p => p.Surname).IsRequired();
                e.Property(p => p.Email).IsRequired();
                e.Property(p => p.Category).IsRequired();
                e.Property(p => p.SubCategory).IsRequired();
            });
        }
    }
}

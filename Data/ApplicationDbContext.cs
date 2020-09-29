using System;
using System.Collections.Generic;
using System.Text;
using ContactBook.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // creating database set of the contacts in context
        public DbSet<Contacts> tContacts { get; set; }
        // creating database set of the contacts in context
        public DbSet<ContactBook.Models.PersonBio> PersonBio { get; set; }
        // creating database set of the contacts in context
        public DbSet<ContactBook.Models.Social> Social { get; set; }
    }
}

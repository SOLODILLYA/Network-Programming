using EmailManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager
{
    public class EmailDatabase : DbContext
    {
        public EmailDatabase() : base("DefaultConnection")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

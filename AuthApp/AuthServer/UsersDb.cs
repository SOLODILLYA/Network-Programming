using AuthServer.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace AuthServer
{
    public class UsersDb : DbContext
    {
        public UsersDb()
            : base("name=UsersDb")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
    }
}
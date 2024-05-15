using System;
using System.Data.Entity;
using System.Linq;
using Models;

namespace AppServer
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<MyTask> MyTasks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
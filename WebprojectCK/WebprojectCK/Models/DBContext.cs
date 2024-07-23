using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebprojectCK.Models
{
    public class DBContext:DbContext
    {
        public DBContext() : base("Mycnstring") { }
        public DbSet<Brands> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Cart> Cart { get; set; }

    }
}
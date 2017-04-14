using juve.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace juve.DAL
{
    public class DataContext:DbContext
    {
       
        public DbSet<Player> Player { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Coment> Coment { get; set; }
        public DbSet<User> User { get; set; }
    }
}
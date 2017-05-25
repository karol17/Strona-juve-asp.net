using juve.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace juve.DAL
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
       
        
        public static DataContext Create()
        {
            return new DataContext();
        }
        public DbSet<Player> Player { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Coment> Coment { get; set; }
      
    }
}
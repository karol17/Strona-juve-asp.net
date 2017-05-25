using juve.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace juve.DAL
{
    public class DataContext: IdentityDbContext<IdentityModels.ApplicationUser>
    {
       public DataContext():base("DataContext")
        {
            
        }
        public static DataContext Create()
        {
            return new DataContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Player> Player { get; set; }
        public DbSet<News> News { get; set; }
       // public DbSet<Coment> Coment { get; set; }
        //public DbSet<User> User { get; set; }
    }
}
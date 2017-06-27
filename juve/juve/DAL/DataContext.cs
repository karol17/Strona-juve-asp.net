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
        //static DataContext()
        //{
        //    Database.SetInitializer<DataContext>(new JuveInitializer());
        //}    
        public static DataContext Create()
        {
            return new DataContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Club> Club { get; set; }
    }
}
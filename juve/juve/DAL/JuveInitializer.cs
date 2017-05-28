using juve.Migrations;
using juve.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace juve.DAL
{
    public class JuveInitializer : DropCreateDatabaseAlways<DataContext>
        //MigrateDatabaseToLatestVersion<DataContext,Configuration>
    {
        public static void SeedData(DataContext context)
        {
            List<Player> players = new List<Player>
            {
                new Player() {PlayerId=1,FirstName="Gianluigi ",LastName="Buffon",BirthDay=new DateTime(1978,1,28),
                    Number =1,Position=Position.Bramkarz,GoalCount=0,Photo="bufon.jpg"},
                new Player() {PlayerId=2,FirstName="Norberto  ",LastName="Neto",BirthDay=new DateTime(1989,7,19),
                    Number =25,Position=Position.Bramkarz,GoalCount=0,Photo="neto.jpg"},
                new Player() {PlayerId=3,FirstName="Giorgio  ",LastName="Chiellini",BirthDay=new DateTime(1984,8,14),
                    Number =5,Position=Position.Obrońca,GoalCount=5,Photo="chiellini.jpg"},
                new Player() {PlayerId=4,FirstName="Medhi  ",LastName="Benatia",BirthDay=new DateTime(1987,4,17),
                    Number =4,Position=Position.Obrońca,GoalCount=0,Photo="benatia.jpg"},
                new Player() {PlayerId=5,FirstName="Alex  ",LastName="Sandro",BirthDay=new DateTime(1991,1,26),
                    Number =12,Position=Position.Obrońca,GoalCount=4,Photo="alex-sandro.jpg"}
            };
            players.ForEach(p => context.Player.AddOrUpdate(p));
            context.SaveChanges();
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juve.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int ScoredGoals { get; set; }
        public int LostGoals { get; set; }
        //public int Goals { get; set; }
               

    }
}
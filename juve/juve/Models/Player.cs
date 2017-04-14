﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juve.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public DateTime BirthDay { get; set; }
        public string Photo { get; set; }
        public Position Position { get; set; }
        public int GoalCount { get; set; }
    }
    public enum Position
    {
        GoalKeaper,
        Defender,
        Midfielder,
        Attacker
    }
}
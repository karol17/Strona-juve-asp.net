using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace juve.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adres { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace juve.Models
{
    public class UserData
    {
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Display(Name ="Nazwisko" )]
        public string LastName { get; set; }

        public string Adres { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }

        

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        public string Email { get; set; }
    }
}
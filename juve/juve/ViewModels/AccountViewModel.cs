using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using juve.Migrations;

namespace juve.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Wprowadź email.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wprowadź hasło.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30,
            ErrorMessage = "{0} musi mieć conajmniej {2} znaków",
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasła nie są takie same")]  
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "{0} musi mieć conajmniej {2} zanków",MinimumLength = 6)]    
        public string Login { get; set; }

        //private UserData userData { get; set; }
    }
}
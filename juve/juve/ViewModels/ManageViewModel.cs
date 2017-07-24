using juve.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace juve.ViewModels
{
    public class ManageCredentialViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public juve.Controllers.ManageController.ManageMessageId? Message { get; set; }
        public UserData UserData { get; set; }

    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(30,ErrorMessage = "Hasło musi zawierać od {0} do {2} znaków",MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("NewPassword",ErrorMessage = "Nowe hasła nie są identyczne")]
        public string ConfirmPassword { get; set; }
    }
}
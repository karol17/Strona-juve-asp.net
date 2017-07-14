using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using juve.App_Start;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using juve.Models;
using Microsoft.AspNet.Identity;
using juve.ViewModels;
using static juve.Models.IdentityModels;

namespace juve.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }
        //public enum ManageMessageId
        //{
        //    AddPhoneSuccess,
        //    ChangePasswordSuccess,
        //    SetTwoFactorSuccess,
        //    SetPasswordSuccess,
        //    RemoveLoginSuccess,
        //    RemovePhoneSuccess,
        //    Error
        //}
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext()
                           .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            } 
            
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //GET: Manage
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var model = new ManageCredentialViewModel
            {
                Message = message,
                
                UserData = user.UserData

            };
            return View(model);
        }
        //public async Task<ActionResult> Index(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.ChangePasswordSuccess ? "Zmieniono hasło."
        //            : message == ManageMessageId.SetPasswordSuccess ? "Ustawiono hasło."
        //                //: message == ManageMessageId.SetTwoFactorSuccess ? "Ustawiono dostawcę uwierzytelniania dwuetapowego."
        //                //    : message == ManageMessageId.Error ? "Wystąpił błąd."
        //                //        : message == ManageMessageId.AddPhoneSuccess ? "Dodano numer telefonu."
        //                //            : message == ManageMessageId.RemovePhoneSuccess ? "Usunięto numer telefonu."
        //                                : "";

        //    var userId = User.Identity.GetUserId();
        //    var model = new ChangePasswordViewModel
        //    {

        //        HasPassword = HasPassword(),
        //        PhoneNumber = await UserManager.GetPhoneNumberAsync(userId),
        //        TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
        //        Logins = await UserManager.GetLoginsAsync(userId),
        //        BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
        //    };
        //    return View(model);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")] UserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userData;
                var result = await UserManager.UpdateAsync(user);
                AddErrors(result);
            }
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")] ChangePasswordViewModel model)
            
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }
            var result =
                await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);

                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }
            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("passwordError", error);
            }
        }
     
        ////
        //// POST: /Manage/ChangePassword
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //        if (user != null)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //        }
        //        return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
        //    }
        //    AddErrors(result);
        //    return View(model);
        //}


        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent}, await user.GenerateUserIdentityAsync(UserManager));

        }
    }
}
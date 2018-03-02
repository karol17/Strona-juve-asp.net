using juve.App_Start;
using juve.DAL;
using juve.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using juve.ViewModels;

namespace juve.Controllers
{
    
    public class CommentController : Controller
    {
      
        DataContext db = new DataContext();
        // GET: Coment
        [HttpPost]
        public ActionResult AddComment(ArticleViewModel vm)
        {
            if (!ModelState.IsValid)
            {
               
                ModelState.AddModelError("", "Error: Nie dodano komentarza!");
                return RedirectToAction("FullArticle", "Home", new { id = vm.NewsId });
            }
            
            var comment = new Comment()
            {
                Text = vm.CommentText,
                NewsId = vm.NewsId,
                Login = User.Identity.GetUserName(),
                Date = DateTime.Now
            };
            db.Comment.Add(comment);
            db.SaveChanges();
            return RedirectToAction("FullArticle","Home",new {id=vm.NewsId});
        }
        
        
        
    }
}
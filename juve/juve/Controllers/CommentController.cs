using juve.DAL;
using juve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace juve.Controllers
{
    
    public class CommentController : Controller
    {
       
        DataContext db = new DataContext();
        // GET: Coment
        public ActionResult AddComent(int ?id,Comment comment)
        {
            //News news = db.News.FirstOrDefault(m => m.NewsId == id);

            News news = db.News.Find(id);



            if (!ModelState.IsValid)
            {
                return View(comment);
            }
            news.Comment.Add(comment);
            return View();
        }
    }
}
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
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
       
        // GET: Home
        public ActionResult Index()
        {
            

            return View(db.News.ToList());
        }
        public ActionResult FullArticle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            return View(news);
        }
        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
        public ActionResult Squad()
        {
            return View(db.Player.ToList());
        }
        public ActionResult Player(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Player.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }
    }
}
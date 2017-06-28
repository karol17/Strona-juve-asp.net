using juve.DAL;
using juve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using juve.ViewModels;
using PagedList;

namespace juve.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
       
        // GET: Home
        public ActionResult Index(int? page)
        {
            //List<News> newses = db.News.ToList();
            var newses = from n in db.News
                select n;
            newses = newses.OrderByDescending(n => n.Title);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            return View(newses.ToPagedList(pageNumber,pageSize));
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
            var comments=db.Comment.Where(c => c.NewsId == id).ToList();
           
            
            var vm = new ArticleViewModel()
            {
                ArticleTitle = news.Title,
                ArticleText = news.Text,
                ArticleHeader = news.Header,
                ArticleImage = news.Image,
                NewsId = news.NewsId,
                Comments = comments
            };
            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //vm.Comments.ToPagedList(pageSize, pageNumber);
            return View(vm);
        }
        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }

        public ActionResult Squad()
        {
            //var player = db.Player.ToList();
          
            return View(db.Player.ToList());
        }

        [HttpPost]
        public ActionResult Squad(string nazwiskoZnajdz)
        {
            //var player = db.Player.ToList();
            var players = from p in db.Player
                select p;
            if (!String.IsNullOrEmpty(nazwiskoZnajdz))
            {
                players = from p in db.Player
                    where p.LastName.Equals(nazwiskoZnajdz)
                    || p.FirstName.Equals(nazwiskoZnajdz)
                    select p;
            }
            return View(players.ToList());
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
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
        //TODO
        public ActionResult Squad(string search=null)
        {
            //var player = db.Player.ToList();
            var players = from p in db.Player
                select p;
            if (search!=null)
            {
                players.Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search) ||
                                   search == p.FirstName + " " + p.LastName).ToList();
                    
            }
            else
            {
                players.ToList();
            }
            if (Request.IsAjaxRequest())
                return View(players);
            return View();
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

        public ActionResult PlayerSuggestions(string term)
        {
            var players = db.Player.Where(p => p.FirstName.Contains(term) || p.LastName.Contains(term))
                .Take(4).Select(p => new {label = p.FirstName + " " + p.LastName});
            return Json(players, JsonRequestBehavior.AllowGet);
        }
    }
}
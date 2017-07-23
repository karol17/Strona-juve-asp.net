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
           
            return View(vm);
        }
        public ActionResult StronyStatyczne(string nazwa)
        {
            return View(nazwa);
        }
        
    }
}
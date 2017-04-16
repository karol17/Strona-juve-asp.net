using juve.DAL;
using juve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
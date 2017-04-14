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
        private DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            Player player = new Models.Player { PlayerId = 1, FirstName = "Paulo", LastName = "Dybala" };
            db.Player.Add(player);
            db.SaveChanges();
            return View();
        }
    }
}
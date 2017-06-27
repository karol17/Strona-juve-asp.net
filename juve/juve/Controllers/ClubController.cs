using juve.DAL;
using juve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace juve.Controllers
{
    public class ClubController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Club
        public ActionResult Index()
        {
            List<Club> clubs = new List<Club>();
            clubs = db.Club.ToList();
            var result = from m in clubs
                         orderby m.Points descending, m.ScoredGoals 
                         select m;

            return View(result);
            //return PartialView("_TablePartial", result);
        }
    }
}
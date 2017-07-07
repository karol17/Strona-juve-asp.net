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
          
            var result = from m in db.Club
                         orderby m.Points descending, m.ScoredGoals 
                         select m;

            //return View(result);
            return PartialView("_TablePartial", result.ToList());
        }
    }
}
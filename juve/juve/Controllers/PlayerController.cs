using juve.DAL;
using juve.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace juve.Controllers
{
    public class PlayerController : Controller
    {
         private DataContext db = new DataContext();
        // GET: Player
        public ActionResult Index(string searchQuery = null)
        {
            
            //IEnumerable<Player> players;
            //if (searchQuery != null)
            //{
            //    players=db.Player.Where(p => p.FirstName.Contains(searchQuery) || p.LastName.Contains(searchQuery) ||
            //                                 searchQuery == p.FirstName + " " + p.LastName).ToList();

            //}
            //else
            //{
            //    players = db.Player.ToList();
            //}
            var players = db.Player.Where(p => searchQuery == null ||
                                               p.FirstName.ToLower().Contains(searchQuery.ToLower()) ||
                                               p.LastName.ToLower().Contains(searchQuery.ToLower()));
            
            if (Request.IsAjaxRequest())
                return PartialView("_PlayerList",players);
            return View(players);
        }
        
        public ActionResult PlayerSuggestions(string term)
        {
            var players = db.Player.Where(p => p.FirstName.ToLower().Contains(term) || p.LastName.ToLower().Contains(term))
                .Take(4).Select(p => new { label = p.FirstName + " " + p.LastName });
            return Json(players, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PlayerDatails(int? id)
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
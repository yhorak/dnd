using Business.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Spells()
        {
            ViewBag.Message = "It's a Magic, bitch";
            var repo = new SpellsRepo();
            return View(repo.GetAllSpells());
        }
    }
}
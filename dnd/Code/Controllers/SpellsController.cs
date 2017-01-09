using System.Collections.Generic;
using Business.Repository;
using System.Web.Mvc;
using dnd.Code.Models;
using Models;
using Models.Spells;

namespace dnd.Code.Controllers
{
    public class SpellsController : Controller
    {
        readonly ISpellsRepo _repo;
        public SpellsController(ISpellsRepo repo)
        {
            _repo = repo;
        }

        // GET: Spells
        public ActionResult Index()
        {
            ViewBag.Message = "It's a Magic, bitch";
            return View(_repo.GetAll());
        }

        public ActionResult Create()
        {
            //ViewBag.Schools = getSchools();
            return View("Edit", new SpellExt() { Schools =  getSchools()});
        }

        public ActionResult Edit(int id)
        {
            //ViewBag.Schools = getSchools();
            return View("Edit", new SpellExt(_repo.Get(id)) { Schools = getSchools()});
        }

        public ActionResult Details(int id)
        {
            return View("Details", _repo.Get(id));
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Spell spell)
        {
            if (spell.Id == 0)
            {
                _repo.Add(spell);
            }
            else
            {
                _repo.Edit(spell);
            }
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> getSchools()
        {
            var items = new List<SelectListItem>();
            foreach (var school in _repo.GetSchools())
            {
                items.Add(new SelectListItem() { Value = school.Value.ToString(), Text = school.Key });
            }
            return items;

        }
    }
}
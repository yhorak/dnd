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

        [Authorize(Roles = "Admin")]
        public ActionResult Create(bool addMore = false)
        {
            //ViewBag.Schools = getSchools();
            return View("Edit", new SpellExt() { Id = 0, Schools = getSchools(), AddMore = addMore, });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View("Edit", new SpellExt(_repo.Get(id))
            {
                Schools = getSchools()                
            });
        }

        public ActionResult Details(int id)
        {
            return View("Details", _repo.Get(id));
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int Id)
        {
            _repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(SpellViewModel spell)
        {
            if (spell.Id == 0)
            {
                _repo.Add(spell);
            }
            else
            {
                _repo.Edit(spell);
            }

            if (spell.AddMore)
            {
                return RedirectToAction(nameof(Create), new { addMore = true });
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
using Business.Repository;
using System.Web.Mvc;
using Models;

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
            return View("Edit", new Spell());
        }

        public ActionResult Edit(int id)
        {
            return View("Edit", _repo.Get(id));
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
    }
}
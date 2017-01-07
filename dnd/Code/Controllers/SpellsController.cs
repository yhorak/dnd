using Business.Repository;
using System.Web.Mvc;
using Models;

namespace dnd.Code.Controllers
{
    public class SpellsController : Controller
    {
        SpellsRepo _repo = new SpellsRepo();
        public SpellsController()
        {

        }
        // GET: Spells
        public ActionResult Index()
        {
            ViewBag.Message = "It's a Magic, bitch";
            var repo = new SpellsRepo();
            return View(repo.GetAllSpells());
        }

        public ActionResult Create()
        {
            return View("Edit", new Spell());
        }

        public ActionResult Edit(int id)
        {
            var repo = new SpellsRepo();

            return View("Edit", repo.Get(id));
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            var repo = new SpellsRepo();
            repo.Delete(Id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Spell spell)
        {
            var repo = new SpellsRepo();
            if (spell.Id == 0)

            { repo.Add(spell); }
            else
            {
                repo.Edit(spell);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
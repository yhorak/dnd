using System.Collections.Generic;
using System.Linq;
using DataAccess;
using AutoMapper;

namespace Business.Repository
{

    public class SpellsRepo
    {
        static SpellsRepo()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Models.Spell, Spell>());
            Mapper.Initialize(cfg => cfg.CreateMap<Spell, Models.Spell>());
        }

        public IEnumerable<Models.Spell> GetAllSpells()
        {
            using (var context = new dnd5eEntities())
            {
                return context.Spells.OrderBy(it => it.Level).ToList().Select(it => Mapper.Map<Models.Spell>(it));
            }
        }

        public Models.Spell Get(int Id)
        {
            using (var context = new dnd5eEntities())
            {
                var item = context.Spells.First(it=>it.Id == Id);
                return Mapper.Map<Models.Spell>(item);
            }
        }

        public void Delete(int Id)
        {
            using (var context = new dnd5eEntities())
            {
                var existing = context.Spells.Find(Id);
                context.Spells.Remove(existing);
                context.SaveChanges();
            }
        }

        public void Add(Models.Spell spell)
        {
            using (var context = new dnd5eEntities())
            {
                context.Spells.Add(Mapper.Map<Spell>(spell));
                context.SaveChanges();
            }
        }

        public void Edit(Models.Spell spell)
        {
            using (var context = new dnd5eEntities())
            {
                var existing = context.Spells.Find(spell.Id); 
                existing.CastDuration = spell.CastDuration;
                context.SaveChanges();
            }
        }
    }
}

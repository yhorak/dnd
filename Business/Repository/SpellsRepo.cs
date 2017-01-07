using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess;
using AutoMapper;

namespace Business.Repository
{

    public class SpellsRepo : ISpellsRepo
    {
        static SpellsRepo()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Models.Spell, Spell>());
            Mapper.Initialize(cfg => cfg.CreateMap<Spell, Models.Spell>()
                .ForMember(it => it.School, it => it.MapFrom(src => src.SpellSchool.Name)));


        }

        public IEnumerable<Models.Spell> GetAll()
        {
            using (var context = new dnd5eEntities())
            {
                return context.Spells.Include(it => it.SpellSchool).OrderBy(it => it.Level).ToList().Select(Mapper.Map<Models.Spell>);
            }
        }

        public Models.Spell Get(int id)
        {
            using (var context = new dnd5eEntities())
            {
                var item = context.Spells.First(it => it.Id == id);
                return Mapper.Map<Models.Spell>(item);
            }
        }

        public void Delete(int id)
        {
            using (var context = new dnd5eEntities())
            {
                var existing = context.Spells.Find(id);
                if (existing == null) return;
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

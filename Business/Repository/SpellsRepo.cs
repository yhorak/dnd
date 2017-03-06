using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccess;
using AutoMapper;
using AutoMapper.Mappers;
using BlSpell = Models.Spell;

namespace Business.Repository
{

    public class SpellsRepo : ISpellsRepo
    {
        static SpellsRepo()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Spell, BlSpell>()
                .ForMember(it => it.School, it => it.MapFrom(src => src.SpellSchool.Name)));
        }

        public IEnumerable<int> GetClassSpells(int classId = 1)
        {
            using (var context = new dnd5eEntities())
            {
                return context.Classes.First(it => it.Id == classId).ClassSpells.Select(it => it.SpellId).ToList();
            }
        }

        public Dictionary<string, int> GetSchools()
        {
            using (var context = new dnd5eEntities())
            {
                return context.SpellSchools.ToDictionary(it => it.Name, it => it.Id);
            }
        }

        public IEnumerable<BlSpell> GetAll()
        {
            using (var context = new dnd5eEntities())
            {
                return context.Spells.Include(it => it.SpellSchool).OrderBy(it => it.Level).ThenBy(it => it.Name).ToList().Select(Mapper.Map<BlSpell>);
            }
        }

        public BlSpell Get(int id)
        {
            using (var context = new dnd5eEntities())
            {
                var item = context.Spells.First(it => it.Id == id);
                return Mapper.Map<BlSpell>(item);
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

        public void Add(BlSpell spell)
        {
            using (var context = new dnd5eEntities())
            {
                var obj = map(spell);
                context.Spells.Add(obj);
                context.SaveChanges();
            }
        }

        public void Edit(BlSpell spell)
        {
            using (var context = new dnd5eEntities())
            {
                var mapped = map(spell);
                context.Spells.Attach(mapped);
                context.Entry(mapped).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private Spell map(BlSpell source)
        {
            var spell = new Spell
            {
                CastDuration = source.CastDuration,
                SchoolId = source.SchoolId,
                Component = source.Component,
                Description = source.Description,
                Id = source.Id,
                Duration = source.Duration?.Trim(),
                Name = source.Name?.Trim(),
                IsRitual = source.IsRitual,
                IsMaterialComponent = source.IsMaterialComponent,
                IsSomaticComponent = source.IsSomaticComponent,
                IsVoiceComponent = source.IsVoiceComponent,
                Level = source.Level,
                NeedConcentration = source.NeedConcentration,
                Range = source.Range,
                RelatedBook = source.RelatedBook,
                Target = source.Target?.Trim(),
                Trigger = source.Trigger?.Trim(),

            };
            return spell;

        }
    }
}

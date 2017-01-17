using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonLogic.Clone;
using Models;

namespace dnd.Code.Models
{
    public class SpellExt : SpellViewModel
    {
        private List<SelectListItem> _schools;

        public SpellExt()
        {
        }

        public SpellExt(Spell source) : this()
        {
            var clone = new ModelsSlowCloner<Spell>();
            clone.Clone(this, source);
            var level = _levels.First(it => it.Value == Level.ToString());
            level.Selected = true;
            var duration = _durations.FirstOrDefault(it => it.Value == Duration.ToString());
            if (duration != null) duration.Selected = true;

            var target = _targets.FirstOrDefault(it => it.Value == Target);
            if (target != null) target.Selected = true;
        }

        public List<SelectListItem> Schools
        {
            get { return _schools; }
            set
            {
                _schools = value;
                if (_schools == null || string.IsNullOrEmpty(School)) return;
                var si = _schools.First(it => it.Text == this.School);
                si.Selected = true;
            }
        }

        public List<SelectListItem> Levels => _levels;

        private readonly List<SelectListItem> _levels = new List<SelectListItem>
        {
            new SelectListItem { Text = "Cantrip", Value = "0"},
            new SelectListItem { Text = "1", Value = "1"},
            new SelectListItem { Text = "2", Value = "2"},
            new SelectListItem { Text = "3", Value = "3"},
            new SelectListItem { Text = "4", Value = "4"},
            new SelectListItem { Text = "5", Value = "5"},
            new SelectListItem { Text = "6", Value = "6"},
            new SelectListItem { Text = "7", Value = "7"},
            new SelectListItem { Text = "8", Value = "8"},
            new SelectListItem { Text = "9", Value = "9"}
        };

        public List<SelectListItem> CastDurations { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Text = "1 реакция", Value = "1 реакция"},
            new SelectListItem { Text = "1 бонусна дія", Value = "1 бонусна дія"},
            new SelectListItem { Text = "1 дія", Value = "1 дія"},
            new SelectListItem { Text = "1 хв", Value = "1 хв"},
            new SelectListItem { Text = "10 хв", Value = "10 хв"},
            new SelectListItem { Text = "1 година", Value = "1 година"},
            new SelectListItem { Text = "8 годин", Value = "8 годин"},
            new SelectListItem { Text = "12 годин", Value = "12 годин"},
            new SelectListItem { Text = "24 години", Value = "24 години"},
        };

        public List<SelectListItem> Durations => _durations;

        private readonly List<SelectListItem> _durations = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Миттєва", Value = "Миттєва"},
            new SelectListItem { Text = "1 раунд", Value = "1 раунд"},
            new SelectListItem { Text = "До 1 хв включно", Value = "До 1 хв включно"},
            new SelectListItem { Text = "1 хв", Value = "1 хв"},
            new SelectListItem { Text = "До 10 хв включно", Value = "До 10 хв включно"},
            new SelectListItem { Text = "До години включно", Value = "До години включно"},
            new SelectListItem { Text = "1 година", Value = "1 година"},
            new SelectListItem { Text = "2 годин", Value = "2 годин"},
            new SelectListItem { Text = "8 годин", Value = "8 годин"},
            new SelectListItem { Text = "24 години", Value = "24 години"},
            new SelectListItem { Text = "7 днів", Value = "7 днів"},
            new SelectListItem { Text = "10 днів", Value = "10 днів"},
            new SelectListItem { Text = "30 днів", Value = "30 днів"},
            new SelectListItem { Text = "Поки не розсіється", Value = "Поки не розсіється"},
            new SelectListItem { Text = "Поки не розсіється або не спрацює", Value = "Поки не розсіється або не спрацює"},
            new SelectListItem { Text = "Особлива", Value = "Особлива"},
        
          
            //new SelectListItem { Text = "9", Value = "9"}
        };

        public List<SelectListItem> Targets => _targets;

        private readonly List<SelectListItem> _targets = new List<SelectListItem>()
        {
            new SelectListItem { Text = "На себе", Value = "На себе"},
            new SelectListItem { Text = "Дотик", Value = "Дотик"},
            new SelectListItem { Text = "Див. опис", Value = "Див. опис"},
            //new SelectListItem { Text = "1 хв", Value = "1 хв"},
            //new SelectListItem { Text = "До 10 хв включно", Value = "До 10 хв включно"},
            //new SelectListItem { Text = "До години включно", Value = "До години включно"},
            //new SelectListItem { Text = "10 днів", Value = "10 днів"},
            //new SelectListItem { Text = "6", Value = "6"},
            //new SelectListItem { Text = "7", Value = "7"},
            //new SelectListItem { Text = "8", Value = "8"},
            //new SelectListItem { Text = "9", Value = "9"}
        };
    }
}
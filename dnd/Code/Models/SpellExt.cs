using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommonLogic.Clone;
using Models;

namespace dnd.Code.Models
{
    public class SpellExt : Spell
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

        public List<SelectListItem> Levels
        {
            get { return _levels; }
        }
        private List<SelectListItem> _levels = new List<SelectListItem>()
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
    }
}
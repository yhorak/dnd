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
        }

        public List<SelectListItem> Schools
        {
            get { return _schools; }
            set
            {
                _schools = value;
                if (_schools == null) return;
                var si = _schools.First(it => it.Text == this.School);
                si.Selected = true;
            }
        }
    }
}
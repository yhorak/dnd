using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Spells
{
    public class EditSpellModel
    {
        public Spell Spell { get; set; }
        public Dictionary<string, int> Schools { get; set; }
    }
}

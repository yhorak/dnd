﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class SpellsRepo
    {
        public IEnumerable<DataAccess.Spell> GetAllSpells()
        {
            return new DataAccess.dnd5eEntities().Spells.ToList();
        }
    }
}

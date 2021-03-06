﻿using System.Collections.Generic;
using Models;

namespace Business.Repository
{
    public interface ISpellsRepo
    {
        void Add(Spell spell);
        void Delete(int id);
        void Edit(Spell spell);
        Spell Get(int id);
        IEnumerable<Spell> GetAll();
        Dictionary<string, int> GetSchools();
        IEnumerable<int> GetClassSpells(int classId = 1);
    }
}
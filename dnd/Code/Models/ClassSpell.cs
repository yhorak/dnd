﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dnd.Code.Models
{
    public class ClassSpell
    {
        public List<int> SelectedSpells { get; set; }
        public IEnumerable<SelectListItem> AllSpells { get; set; }


    }
}
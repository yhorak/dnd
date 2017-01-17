using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace dnd.Code.Models
{
    public class SpellViewModel : Spell
    {
        public bool AddMore { get; set; } = true;
    }
}
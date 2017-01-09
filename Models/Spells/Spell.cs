using System.ComponentModel;
using CommonLogic.Clone;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Spell
    {
        [CloneProperty]
        public int Id { get; set; }
        [CloneProperty]
        [Required]
        public short Level { get; set; }
        [CloneProperty]
        public string Name { get; set; }

        [CloneProperty]
        public string School { get; set; } = "Втілення";

        [CloneProperty]
        public int SchoolId { get; set; } = 1;
        [CloneProperty]
        public bool IsRitual { get; set; }

        [CloneProperty]
        public string CastDuration { get; set; } = "1 дія";

        [CloneProperty]
        public int Range { get; set; } = 30;
        [CloneProperty]
        public string Duration { get; set; }
        [CloneProperty]
        public string Description { get; set; }
        [CloneProperty]
        public bool IsVoiceComponent { get; set; } = true;
        [CloneProperty]
        public bool IsSomaticComponent { get; set; } 
        [CloneProperty]
        public bool IsMaterialComponent { get; set; }
        [CloneProperty]
        public string Component { get; set; }

        [CloneProperty]
        public string Target { get; set; } = "На себе";
        [CloneProperty]
        public string Trigger { get; set; }
        [CloneProperty]
        public string SaveThrow { get; set; }
        [CloneProperty]
        public bool NeedConcentration { get; set; }
        [CloneProperty]
        public string RelatedBook { get; set; } = "Книга гравця";

    }
}

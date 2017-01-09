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
        [Range(0, 9)]
        public short Level { get; set; }
        [CloneProperty]
        public string Name { get; set; }
        [CloneProperty]
        public string School { get; set; }
        [CloneProperty]
        public int SchoolId { get; set; }
        [CloneProperty]
        public bool IsRitual { get; set; }
        [CloneProperty]
        public string CastDuration { get; set; }
        [CloneProperty]
        public int Range { get; set; }
        [CloneProperty]
        public string Duration { get; set; }
        [CloneProperty]
        public string Description { get; set; }
        [CloneProperty]
        public bool IsVoiceComponent { get; set; }
        [CloneProperty]
        public bool IsSomaticComponent { get; set; } = true;
        [CloneProperty]
        public bool IsMaterialComponent { get; set; }
        [CloneProperty]
        public string Component { get; set; }
        [CloneProperty]
        public string Target { get; set; }
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

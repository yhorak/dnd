//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Spell
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Spell()
        {
            this.ClassSpells = new HashSet<ClassSpell>();
        }
    
        public int Id { get; set; }
        public short Level { get; set; }
        public string Name { get; set; }
        public bool IsRitual { get; set; }
        public string CastDuration { get; set; }
        public int Range { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public bool IsVoiceComponent { get; set; }
        public bool IsSomaticComponent { get; set; }
        public bool IsMaterialComponent { get; set; }
        public string Component { get; set; }
        public string Target { get; set; }
        public string Trigger { get; set; }
        public bool NeedConcentration { get; set; }
        public string RelatedBook { get; set; }
        public Nullable<int> SchoolId { get; set; }
    
        public virtual SpellSchool SpellSchool { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassSpell> ClassSpells { get; set; }
    }
}

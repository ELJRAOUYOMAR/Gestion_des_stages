//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projectezeze.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tach
    {
        public int ID { get; set; }
        public Nullable<int> IdTache { get; set; }
        public Nullable<int> IdStage { get; set; }
    
        public virtual Tache Tache { get; set; }
    }
}

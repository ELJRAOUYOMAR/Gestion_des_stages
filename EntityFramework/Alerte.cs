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
    
    public partial class Alerte
    {
        public int IdAlerte { get; set; }
        public string Contenu { get; set; }
        public Nullable<System.DateTime> DateCreation { get; set; }
        public string Status { get; set; }
        public Nullable<int> IdStage { get; set; }
    
        public virtual Stage Stage { get; set; }
    }
}

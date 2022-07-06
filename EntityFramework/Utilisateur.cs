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
    
    public partial class Utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilisateur()
        {
            this.Historiques = new HashSet<Historique>();
            this.TypeRoles = new HashSet<TypeRole>();
        }
    
        public int IdUtilisateur { get; set; }
        public string Cin { get; set; }
        public string NomComplet { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public Nullable<bool> Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historique> Historiques { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeRole> TypeRoles { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assoc_Utilisateur_vehicule
    {
        public int id_association { get; set; }
        public Nullable<int> id_vehicule { get; set; }
        public Nullable<int> id_utilisateur { get; set; }
    
        public virtual Vehicule Vehicule { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
    }
}

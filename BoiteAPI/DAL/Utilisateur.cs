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
    
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            this.Assoc_Utilisateur_vehicule = new HashSet<Assoc_Utilisateur_vehicule>();
            this.Covoiturage = new HashSet<Covoiturage>();
            this.Reservation = new HashSet<Reservation>();
        }
    
        public int id_utilisateur { get; set; }
        public string prenom { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string profil_image { get; set; }
        public string nom { get; set; }
    
        public virtual ICollection<Assoc_Utilisateur_vehicule> Assoc_Utilisateur_vehicule { get; set; }
        public virtual ICollection<Covoiturage> Covoiturage { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}

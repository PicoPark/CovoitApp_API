﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CovoitEntities : DbContext
    {
        public CovoitEntities()
            : base("name=CovoitEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Assoc_Utilisateur_vehicule> Assoc_Utilisateur_vehicule { get; set; }
        public DbSet<Covoiturage> Covoiturage { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Vehicule> Vehicule { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GYMWebApp.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorkOutDBEntities : DbContext
    {
        public WorkOutDBEntities()
            : base("name=WorkOutDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Antreman> Antreman { get; set; }
        public virtual DbSet<HareketAltGrubu> HareketAltGrubu { get; set; }
        public virtual DbSet<HareketGrubu> HareketGrubu { get; set; }
        public virtual DbSet<Olcum> Olcum { get; set; }
        public virtual DbSet<OlcumTipi> OlcumTipi { get; set; }
        public virtual DbSet<Sporcu> Sporcu { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<AppRole> AppRole { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class brewingEntities : DbContext
    {
        public brewingEntities()
            : base("name=brewingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<fermentable> fermentables { get; set; }
        public virtual DbSet<hop> hops { get; set; }
        public virtual DbSet<misc> miscs { get; set; }
        public virtual DbSet<style> styles { get; set; }
        public virtual DbSet<yeast> yeasts { get; set; }
    }
}
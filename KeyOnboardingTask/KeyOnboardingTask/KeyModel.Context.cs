﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeyOnboardingTask
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KeyDBEntities : DbContext
    {
        public KeyDBEntities()
            : base("name=KeyDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductSold> ProductSolds { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}

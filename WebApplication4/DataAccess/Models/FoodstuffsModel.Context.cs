﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class foodstuffsEntities : DbContext,IfoodstuffsEntities
    {
        public foodstuffsEntities()
            : base("name=foodstuffsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbdcCustomerProfile> tbdcCustomerProfiles { get; set; }
        public virtual DbSet<tbdcProductExtention> tbdcProductExtentions { get; set; }
        public virtual DbSet<tbRetailTlogStoresToProcess> tbRetailTlogStoresToProcesses { get; set; }
        public virtual DbSet<tbdcInventory> tbdcInventories { get; set; }
        public DbSet<ShoppingList> shoppingList { get; set; }
        public virtual DbSet<tbdcPredictItem> tbdcPredictItems { get; set; }
        public virtual DbSet<tbMasterArticleDepartment> tbMasterArticleDepartments { get; set; }
        public virtual DbSet<tbMasterArticleDescription> tbMasterArticleDescriptions { get; set; }
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; }
        public virtual DbSet<tbdcBasicShopList> tbdcBasicShopLists { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S3G2_PVFAPP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class S3G2PVFEntities : DbContext
    {
        public S3G2PVFEntities()
            : base("name=S3G2PVFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Business> Business { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Knowledge> Knowledge { get; set; }
        public virtual DbSet<Manufactures> Manufactures { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<Productline> Productline { get; set; }
        public virtual DbSet<Raw_Materials> Raw_Materials { get; set; }
        public virtual DbSet<Sales_Person> Sales_Person { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Supplies> Supplies { get; set; }
        public virtual DbSet<Territory> Territory { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Work> Work { get; set; }
        public virtual DbSet<Work_center> Work_center { get; set; }
    }
}

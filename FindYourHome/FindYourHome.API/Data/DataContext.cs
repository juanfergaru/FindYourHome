﻿using FindYourHome.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FindYourHome.API.Data
{

    //public class DataContext : DbContext
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //Estado/Barrio
        public DbSet<State> States { get; set; }

        //Ciudad
        public DbSet<City> Cities { get; set; }

        //propietario
        public DbSet<Owner> Owners { get; set; }

        //Asesor
        public DbSet<Advisor> Advisors { get; set; }

        //propiedad
        public DbSet<Ownership> Ownerships { get; set; }

        //Arrendatario
        public DbSet<Tenant> Tenants { get; set; }

        //Contrato
        public DbSet<Contract> Contracts { get; set; }

        //Pagos
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<State>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasOne(p => p.State).WithMany(b => b.Cities).HasForeignKey(p => p.StateId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Owner>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Ownership>().Property(o => o.MonthlyPrice).HasPrecision(20, 2);
            modelBuilder.Entity<Ownership>().HasOne(o => o.Owner).WithMany(owner => owner.Ownerships).HasForeignKey(o => o.OwnerId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Advisor>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Ownership>().HasOne(o => o.Advisor).WithMany(advisor => advisor.Ownerships).HasForeignKey(o => o.AdvisorId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ownership>().HasIndex(c => c.Id).IsUnique();

            modelBuilder.Entity<Tenant>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Contract>().HasOne(o => o.Tenant).WithMany(tenant => tenant.Contracts).HasForeignKey(o => o.TenantId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Contract>().HasOne(o => o.Ownership).WithMany(ownership => ownership.Contracts).HasForeignKey(o => o.OwnershipId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contract>().Property(o => o.RentPrice).HasPrecision(20, 2);


            modelBuilder.Entity<Payment>().Property(o => o.PaymentPrice).HasPrecision(20, 2);


        }
    }
}


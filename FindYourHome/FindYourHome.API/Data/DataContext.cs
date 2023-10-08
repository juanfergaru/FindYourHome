using FindYourHome.Shared.Entities;
using Microsoft.EntityFrameworkCore;


namespace FindYourHome.API.Data
{

    public class DataContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //Pais
        public DbSet<Country> Countries { get; set; }

        //Estado/Barrio
        public DbSet<State> States { get; set; }

        //Ciudad
        public DbSet<City> Cities { get; set; }

        //propietario
        public DbSet<Owner> Owners { get; set; }

        //Asesor
        public DbSet<Advisor> Advisors { get; set; }

        //Arrendatario
        public DbSet<Tenant> Tenants { get; set; }

        //propiedad
        public DbSet<Ownership> Ownerships { get; set; }

        //Usuario
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();

            modelBuilder.Entity<User>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Owner>().HasIndex("UserId", "Id").IsUnique();
            modelBuilder.Entity<Tenant>().HasIndex("UserId", "Id").IsUnique();
            modelBuilder.Entity<Advisor>().HasIndex("UserId", "Id").IsUnique();

            //relacion con inmueble (Ownership)
            modelBuilder.Entity<Ownership>().Property(o => o.MonthlyPrice).HasPrecision(20, 2);
            modelBuilder.Entity<Ownership>().HasOne(o => o.Owner).WithMany(owner => owner.Ownerships).HasForeignKey(o => o.OwnerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Ownership>().HasOne(o => o.Advisor).WithMany(advisor => advisor.Ownerships).HasForeignKey(o => o.AdvisorId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}


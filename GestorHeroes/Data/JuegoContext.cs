using GestorHeroes.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorHeroes.Data
{
    public class JuegoContext : DbContext
    {
        public JuegoContext(DbContextOptions<JuegoContext> options) : base(options)
        {

        }

        public DbSet<Personaje> Personajes => Set<Personaje>();
        //public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Guerrero> Guerreros => Set<Guerrero>();
        public DbSet<Mago> Magos => Set<Mago>();
        public DbSet<Arquero> Arqueros => Set<Arquero>();
        public DbSet<Clerigo> Clerigos => Set<Clerigo>();

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Tabla base
        //    modelBuilder.Entity<Personaje>().ToTable("Personajes");

        //    // Campo JSONB
        //    modelBuilder.Entity<Personaje>()
        //        .Property(p => p.Rasgos)
        //        .HasColumnType("jsonb");

        //    // TPT: tablas por tipo
        //    modelBuilder.Entity<Guerrero>().ToTable("Guerreros");
        //    modelBuilder.Entity<Mago>().ToTable("Magos");
        //    modelBuilder.Entity<Arquero>().ToTable("Arqueros");
        //    modelBuilder.Entity<Clerigo>().ToTable("Clerigos");

        //    base.OnModelCreating(modelBuilder);
        //}
    }

}

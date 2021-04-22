using Microsoft.EntityFrameworkCore;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Data
{
    public class StartspelerContext : DbContext
    {
        public StartspelerContext(DbContextOptions<StartspelerContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Inschrijving> Inschrijvingen { get; set; }

        public DbSet<Evenement> Evenementen { get; set; }

        public DbSet<EvenementType> EvenementTypes { get; set; }

        public DbSet<Drankkaart> Drankkaarten { get; set; }

        public DbSet<DrankkaartType> DrankkaartTypes { get; set; }

        public DbSet<Bestelling> Bestellingen { get; set; }

        public DbSet<Product> Producten { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Bestellijn> Bestellijnen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", schema: "SS");
            modelBuilder.Entity<Inschrijving>().ToTable("Inschrijving", schema: "SS");
            modelBuilder.Entity<Evenement>().ToTable("Evenement", schema: "SS");
            modelBuilder.Entity<EvenementType>().ToTable("EvenementType", schema: "SS");
            modelBuilder.Entity<Drankkaart>().ToTable("Drankkaart", schema: "SS");
            modelBuilder.Entity<DrankkaartType>().ToTable("DrankkaartType", schema: "SS");
            modelBuilder.Entity<Bestelling>().ToTable("Bestelling", schema: "SS");
            modelBuilder.Entity<Product>().ToTable("Product", schema: "SS");
            modelBuilder.Entity<Categorie>().ToTable("Categorie", schema: "SS");
            modelBuilder.Entity<Bestellijn>().ToTable("Bestellijn", schema: "SS");
        }
    }
}
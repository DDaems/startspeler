using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StartspelerMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartspelerMVC.Data
{
    public class StartspelerContext : IdentityDbContext<User>
    {
        public StartspelerContext(DbContextOptions<StartspelerContext> options)
            : base(options)
        {
        }
        public StartspelerContext()
        {

        }

        #region DBSet
        public DbSet<Inschrijving> Inschrijvingen { get; set; }
        public DbSet<Evenement> Evenementen { get; set; }
        public DbSet<EvenementType> EvenementTypes { get; set; }
        public DbSet<Drankkaart> Drankkaarten { get; set; }
        public DbSet<DrankkaartType> DrankkaartTypes { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Product> Producten { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("SS");
            #region Remap Identity Tables
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });
            modelBuilder.Entity<IdentityRole>(e =>
            {
                e.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(e =>
            {
                e.ToTable("UserTokens");
            });
            #endregion
            #region Remap Identiy Columns

            #endregion
            #region PK users to ID
            // Besloten om toch maar met de <string>ID van Identity te werken
            // op basis van het volgende.
            // https://github.com/dotnet/aspnetcore/issues/24580

            //modelBuilder.Entity<User>(e =>
            //{
            //    e.HasKey(e => e.UserID);
            //});

            //modelBuilder.Ignore<User>(e => e.Id);
            #endregion
        }
    }
}
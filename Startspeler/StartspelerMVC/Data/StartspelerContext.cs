﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User", schema: "SS");
            modelBuilder.Entity<Inschrijving>().ToTable("Inschrijving", schema: "SS");
            modelBuilder.Entity<Evenement>().ToTable("Evenement", schema: "SS");
            modelBuilder.Entity<EvenementType>().ToTable("EvenementType", schema: "SS");
        }
    }
}
﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository
{
    /// <summary>
    /// Контекст данных необдимых для связи с БД
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<Guidbook> Guidbooks { get; set; }
        public DbSet<ObjectInventory> ObjectsInventory { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) 
            : base(options)
        {

        }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=tz;Username=postgres;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ObjectInventory>(entity =>
            {
                entity.ToTable("objectsinventory");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.count).HasColumnName("count");

                entity.Property(e => e.idType).HasColumnName("idtype");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(512);

                entity.Property(e => e.uniqcode)
                    .HasColumnName("uniqcode")
                    .HasMaxLength(512);
            });

            modelBuilder.Entity<Guidbook>(entity =>
            {
                entity.ToTable("typesobject");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256);
            });
        }
    }
}

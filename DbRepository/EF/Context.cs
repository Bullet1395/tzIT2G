using Entities;
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
        public DbSet<GuidebookTypes> GuidebookTypes { get; set; }
        public DbSet<ObjectInventory> ObjectsInventory { get; set; }

        public Context(DbContextOptions<Context> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GuidebookTypes>(entity =>
            {
                entity.ToTable("typesobject");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ObjectInventory>(entity =>
            {
                entity.ToTable("objectsinventory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.IdType).HasColumnName("idtype");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(512);

                entity.Property(e => e.Uniqcode)
                    .HasColumnName("uniqcode")
                    .HasMaxLength(512);
            });               
        }
    }
}

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
    }
}

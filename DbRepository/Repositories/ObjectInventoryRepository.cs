using DbRepository.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Repositories
{
    public class ObjectInventoryRepository : IRepository<ObjectInventory>
    {
        private readonly Context db;

        public ObjectInventoryRepository(Context context)
        {
            this.db = context;
        }

        public async Task Create(ObjectInventory obj)
        {
            await db.AddAsync(obj);
        }

        public IQueryable<ObjectInventory> GetAllQuery()
        {
            return db.ObjectsInventory.AsQueryable();
        }

        public async Task<IEnumerable<ObjectInventory>> GetAll()
        {
            return await db.ObjectsInventory.ToListAsync();
        }

        public async Task<ObjectInventory> Get(int id)
        {
            return await  db.ObjectsInventory.FindAsync(id);
        }

        public void Update(ObjectInventory obj)
        {
            db.ObjectsInventory.Update(obj);
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var guidBookForDelete = db.ObjectsInventory.Find(id);
            db.Remove(guidBookForDelete);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}

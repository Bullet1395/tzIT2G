using DbRepository.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbRepository.Repositories
{
    public class ObjectInventoryRepository : IRepository<ObjectInventory>
    {
        private readonly Context db;

        public ObjectInventoryRepository(Context context)
        {
            this.db = context;
        }

        public void Create(ObjectInventory obj)
        {
            db.Add(obj);
        }

        public IQueryable<ObjectInventory> GetAll()
        {
            return db.ObjectsInventory;
        }

        public ObjectInventory Get(int id)
        {
            return db.ObjectsInventory.Find(id);
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

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

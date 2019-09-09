using DbRepository.Interfaces;
using Entities;
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

        public async void Create(ObjectInventory obj)
        {
            await Task.Run(() => db.Add(obj));
        }

        public IQueryable<ObjectInventory> GetAllQuery()
        {
            return db.ObjectsInventory.AsQueryable();
        }

        public async Task<IEnumerable<ObjectInventory>> GetAll()
        {
            return await Task.Run(() => db.ObjectsInventory);
        }

        public async Task<ObjectInventory> Get(int id)
        {
            return await Task.Run(() => db.ObjectsInventory.Find(id));
        }

        public async void Update(ObjectInventory obj)
        {
            await Task.Run(() =>
            {
                db.ObjectsInventory.Update(obj);
                db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            });            
        }

        public async void Delete(int id)
        {
            await Task.Run(() =>
            {
                var guidBookForDelete = db.ObjectsInventory.Find(id);
                db.Remove(guidBookForDelete);
            });
            
        }

        public async void Save()
        {
            await Task.Run(() => db.SaveChanges());
        }
    }
}

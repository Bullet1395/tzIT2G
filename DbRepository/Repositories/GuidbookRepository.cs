using DbRepository.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository.Repositories
{

    public class GuidbookRepository : IRepository<Guidbook>
    {
       private Context db;

       public GuidbookRepository(Context context)
        {
            this.db = context;
        }

        public void Create(Guidbook item)
        {
            db.Add(item);
        }

        public IEnumerable<Guidbook> GetAll()
        {
            return db.Guidbooks;
        }

        public Guidbook Get(int id)
        {
            return db.Guidbooks.Find(id);
        }

        public void Update(Guidbook guidBook)
        {  
            db.Guidbooks.Update(guidBook);
            db.Entry(guidBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var guidBookForDelete = db.Guidbooks.Find(id);
            db.Remove(guidBookForDelete);
        }       

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

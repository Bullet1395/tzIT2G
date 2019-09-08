using DbRepository.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository.Repositories
{

    public class GuidebookTypesRepository : IRepository<GuidebookTypes>
    {
       private readonly Context db;

       public GuidebookTypesRepository(Context context)
        {
            this.db = context;
        }

        public void Create(GuidebookTypes item)
        {
            db.Add(item);
        }

        public IEnumerable<GuidebookTypes> GetAll()
        {
            return db.GuidebookTypes;
        }

        public GuidebookTypes Get(int id)
        {
            return db.GuidebookTypes.Find(id);
        }

        public void Update(GuidebookTypes guideBook)
        {  
            db.GuidebookTypes.Update(guideBook);
            db.Entry(guideBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            var guideBookTypeForDelete = db.GuidebookTypes.Find(id);
            db.Remove(guideBookTypeForDelete);
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

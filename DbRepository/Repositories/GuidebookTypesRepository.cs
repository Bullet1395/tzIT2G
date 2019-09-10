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

    public class GuidebookTypesRepository : IRepository<GuidebookTypes>
    {
       private readonly Context db;

       public GuidebookTypesRepository(Context context)
        {
            this.db = context;
        }

        public async Task Create(GuidebookTypes item)
        {
            await db.AddAsync(item);
        }

        public IQueryable<GuidebookTypes> GetAllQuery()
        {
            return db.GuidebookTypes.AsQueryable();
        }

        public async Task<IEnumerable<GuidebookTypes>> GetAll()
        {
            return await db.GuidebookTypes.ToListAsync();
        }

        public async Task<GuidebookTypes> Get(int id)
        {
            return await db.GuidebookTypes.FindAsync(id);           
        }

        public void Update(GuidebookTypes guideBook)
        {
            db.GuidebookTypes.Update(guideBook);
            db.Entry(guideBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;         
        }

        public void Delete(int id)
        {           
            db.Remove(db.GuidebookTypes.Find(id));
        }       

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}

using DbRepository.Interfaces;
using Entities;
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

        public async void Create(GuidebookTypes item)
        {
            await Task.Run(() => db.Add(item));
        }

        public IQueryable<GuidebookTypes> GetAllQuery()
        {
            return db.GuidebookTypes.AsQueryable();
        }

        public async Task<IEnumerable<GuidebookTypes>> GetAll()
        {
            return await Task.Run(() => db.GuidebookTypes);
        }

        public async Task<GuidebookTypes> Get(int id)
        {
            return await Task.Run(() => db.GuidebookTypes.Find(id));           
        }

        public async void Update(GuidebookTypes guideBook)
        {
            await Task.Run(() => {
                db.GuidebookTypes.Update(guideBook);
                db.Entry(guideBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                });            
        }

        public async void Delete(int id)
        {           
            await Task.Run(() => {
                var guideBookTypeForDelete = db.GuidebookTypes.Find(id);
                db.Remove(guideBookTypeForDelete); });
        }       

        public async void Save()
        {
            await Task.Run(() => db.SaveChanges());
        }
    }
}

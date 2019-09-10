using AutoMapper;
using DbRepository.Interfaces;
using DbRepository.Repositories;
using DTO;
using Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Models.Services
{
    public class GuidebookTypesService : IGuideBookTypesService
    {
        private readonly IRepository<GuidebookTypes> db;
        private readonly IMapper mapper;

        public GuidebookTypesService(IRepository<GuidebookTypes> repository, IMapper mapperConf)
        {
            db = repository;
            mapper = mapperConf;
        }

        public async Task AddTypeGuideBookType(GuidebookTypesDTO newGuidebookType)
        {
            var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidebookType);
            await db.Create(mGuidebookType);
            await db.Save();
        }

        public async Task<GuidebookTypesDTO> GetGuideBookType(int id)
        {
            var mGuidebookType = mapper.Map<GuidebookTypes, GuidebookTypesDTO>(await db.Get(id));
            return mGuidebookType;
        }

        public async Task<IEnumerable<GuidebookTypesDTO>> GetGuideBookTypes()
        {
            var mGuidebookTypesList = mapper.Map<IEnumerable<GuidebookTypes>, List<GuidebookTypesDTO>>(await db.GetAll());
            return mGuidebookTypesList;
        }

        public void RemoveGuideBookType(int id)
        {
            db.Delete(id);
            db.Save();
        }

        public void UpdateGuideBookType(GuidebookTypesDTO newGuidBook)
        {
            var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidBook);
            db.Update(mGuidebookType);
            db.Save();
        }
    }
}

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

        public void AddTypeGuideBookType(GuidebookTypesDTO newGuidebookType)
        {
            var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidebookType);
            db.Create(mGuidebookType);
            db.Save();
        }

        public GuidebookTypesDTO GetGuideBookType(int id)
        {
            var mGuidebookType = mapper.Map<GuidebookTypes, GuidebookTypesDTO>(db.Get(id).Result);
            return mGuidebookType;
        }

        public IEnumerable<GuidebookTypesDTO> GetGuideBookTypes()
        {
            var mGuidebookTypesList = mapper.Map<IEnumerable<GuidebookTypes>, List<GuidebookTypesDTO>>(db.GetAll().Result);
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

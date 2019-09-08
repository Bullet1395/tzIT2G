using AutoMapper;
using DbRepository.Interfaces;
using DbRepository.Repositories;
using DTO;
using Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            try
            {
                var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidebookType);
                db.Create(mGuidebookType);
                db.Save();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public GuidebookTypesDTO GetGuideBookType(int id)
        {
            try
            {
                var mGuidebookType = mapper.Map<GuidebookTypes, GuidebookTypesDTO>(db.Get(id));
                return mGuidebookType;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<GuidebookTypesDTO> GetGuideBookTypes()
        {
            try
            {
                var mGuidebookTypesList = mapper.Map<IEnumerable<GuidebookTypes>, List<GuidebookTypesDTO>>(db.GetAll());
                return mGuidebookTypesList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RemoveGuideBookType(int id)
        {
            try
            {
                db.Delete(id);
                db.Save();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateGuideBookType(GuidebookTypesDTO newGuidBook)
        {
            try
            {
                var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidBook);
                db.Update(mGuidebookType);
                db.Save();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}

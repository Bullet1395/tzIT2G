using AutoMapper;
using DbRepository.Interfaces;
using DbRepository.Repositories;
using DTO;
using Entities;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Services
{
    public class GuidebookTypesService : IGuideBookTypesService
    {
        private readonly IRepository<GuidebookTypes> db;

        public GuidebookTypesService(IRepository<GuidebookTypes> repository)
        {
            db = repository;
        }

        public void AddTypeGuideBookType(GuidebookTypesDTO newGuidebookType)
        {            
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypesDTO, GuidebookTypes>()).CreateMapper();
                var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidebookType);
                db.Create(mGuidebookType);
                db.Save();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            finally
            {                
                db.Dispose();
            }
        }

        public GuidebookTypesDTO GetGuideBookType(int id)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypes, GuidebookTypesDTO>()).CreateMapper();
                var mGuidebookType = mapper.Map<GuidebookTypes, GuidebookTypesDTO>(db.Get(id));
                return mGuidebookType;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            finally
            {
                db.Dispose();
            }
        }

        public IEnumerable<GuidebookTypesDTO> GetGuideBookTypes()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypes, GuidebookTypesDTO>()).CreateMapper();
                var mGuidebookTypesList = mapper.Map<IEnumerable<GuidebookTypes>, List<GuidebookTypesDTO>>(db.GetAll());
                return mGuidebookTypesList;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                db.Dispose();
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
            finally
            {
                db.Dispose();
            }
        }

        public void UpdateGuideBookType(GuidebookTypesDTO newGuidBook)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidebookTypesDTO, GuidebookTypes>()).CreateMapper();
                var mGuidebookType = mapper.Map<GuidebookTypesDTO, GuidebookTypes>(newGuidBook);
                db.Update(mGuidebookType);
                db.Save();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}

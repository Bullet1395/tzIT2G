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
    public class GuidbookService : IGuidBookService
    {
        IRepository<Guidbook> db { get; set; }

        public GuidbookService(IRepository<Guidbook> repository)
        {
            db = repository;
        }

        public void AddTypeGuidBook(GuidbookDTO newGuidbook)
        {            
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidbookDTO, Guidbook>()).CreateMapper();
                var mGuidbook = mapper.Map<GuidbookDTO, Guidbook>(newGuidbook);
                db.Create(mGuidbook);
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

        public GuidbookDTO GetGuidBook(int id)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Guidbook, GuidbookDTO>()).CreateMapper();
                var mGuidbook = mapper.Map<Guidbook, GuidbookDTO>(db.Get(id));
                return mGuidbook;
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

        public IEnumerable<GuidbookDTO> GetGuidBooks()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Guidbook, GuidbookDTO>()).CreateMapper();
                var mGuidbookList = mapper.Map<IEnumerable<Guidbook>, List<GuidbookDTO>>(db.GetAll());
                return mGuidbookList;
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

        public void RemoveGuidBook(int id)
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

        public void UpdateGuidBook(GuidbookDTO newGuidBook)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GuidbookDTO, Guidbook>()).CreateMapper();
                var mGuidbook = mapper.Map<GuidbookDTO, Guidbook>(newGuidBook);
                db.Update(mGuidbook);
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

using AutoMapper;
using DbRepository.Interfaces;
using DbRepository.Repositories;
using DTO;
using Entities;
using Models.BL;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.Services
{
    public class ObjectInventoryService : IObjectInventoryService
    {
        IRepository<ObjectInventory> db { get; set; }

        public ObjectInventoryService(IRepository<ObjectInventory> repository)
        {
            db = repository;
        }

        public void AddObjectInventory(ObjectInventoryDTO newObject)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryDTO, ObjectInventory>()).CreateMapper();
                var mObject = mapper.Map<ObjectInventoryDTO, ObjectInventory>(newObject);
                db.Create(mObject);
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

        public ObjectInventoryDTO GetObject(int id)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventory, ObjectInventoryDTO>()).CreateMapper();
                var mObject = mapper.Map<ObjectInventory, ObjectInventoryDTO>(db.Get(id));
                return mObject;
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

        public IEnumerable<ObjectInventoryDTO> GetObjects(Filter optionsFiltering, Sort[] optionsSorting, Pages optionsPages)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventory, ObjectInventoryDTO>()).CreateMapper();

                var mObject = mapper.Map<IEnumerable<ObjectInventory>, List<ObjectInventoryDTO>>(
                    (from obj in db.GetAll()
                     where
                         optionsFiltering.types != null ? optionsFiltering.types.Contains(obj.idType) : true &&
                         (optionsFiltering.names != null && optionsFiltering.names != "") ? obj.name.Contains(optionsFiltering.names) : true &&
                         ((optionsFiltering.minCount != null && optionsFiltering.maxCount != null) ? obj.count >= optionsFiltering.minCount && obj.count <= optionsFiltering.maxCount : 
                            (optionsFiltering.minCount != null && optionsFiltering.maxCount == null) ? obj.count >= optionsFiltering.minCount : 
                                (optionsFiltering.minCount == null && optionsFiltering.maxCount != null) ? obj.count <= optionsFiltering.maxCount : true) &&
                        optionsFiltering.uniqcode != null && optionsFiltering.uniqcode != "" ? obj.uniqcode == optionsFiltering.uniqcode : true
                    select obj).ToList());

                mObject = Sort.Sorting(optionsSorting, mObject).ToList();

                return mObject;
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

        public void RemoveObject(int id)
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

        public void UpdateObject(ObjectInventoryDTO newObject)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventoryDTO, ObjectInventory>()).CreateMapper();
                var mObject = mapper.Map<ObjectInventoryDTO, ObjectInventory>(newObject);
                db.Update(mObject);
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

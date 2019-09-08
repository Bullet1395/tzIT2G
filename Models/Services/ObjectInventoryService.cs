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
        private readonly IRepository<ObjectInventory> db;

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
        }

        public Options GetExampleOptions()
        {
            return
                new Options()
                {
                    OptionsFilter = new Filter()
                    {
                        Types = new List<int>() { 1, 2, 3 },
                        Names = "имя",
                        MinCount = 0,
                        MaxCount = 3,
                        Uniqcode = ""
                    },
                    OptionsSort = new Sort[]
                    {
                        new Sort() { Property = "id", Direction = "Asc" },
                        new Sort() { Property = "name", Direction = "Desc" },
                    },
                    OptionsPage = new Pages()
                    {
                        NumberPage = 1,
                        CountOnPage = 2
                    }
                };
        }

        public ObjectInventoryDTO GetObject(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventory, ObjectInventoryDTO>()).CreateMapper();
            var mObject = mapper.Map<ObjectInventory, ObjectInventoryDTO>(db.Get(Convert.ToInt32(id)));
            return mObject;
        }

        public IEnumerable<ObjectInventoryDTO> GetObjects(Options configOpt)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ObjectInventory, ObjectInventoryDTO>()).CreateMapper();

                var optionsFiltering = configOpt.OptionsFilter;
                var optionsSorting = configOpt.OptionsSort;
                var optionsPages = configOpt.OptionsPage;

                var mObject = mapper.Map<IEnumerable<ObjectInventory>, List<ObjectInventoryDTO>>(
                    (from obj in db.GetAll()
                     where
                        (optionsFiltering.Types != null ? optionsFiltering.Types.Contains(obj.IdType) : true) &&

                        ((optionsFiltering.Names != null || optionsFiltering.Names != "") ? obj.Name.Contains(optionsFiltering.Names) : true) &&

                        ((optionsFiltering.MinCount != null && optionsFiltering.MaxCount != null) ? obj.Count >= optionsFiltering.MinCount && obj.Count <= optionsFiltering.MaxCount :
                            (optionsFiltering.MinCount != null && optionsFiltering.MaxCount == null) ? obj.Count >= optionsFiltering.MinCount :
                                (optionsFiltering.MinCount == null && optionsFiltering.MaxCount != null) ? obj.Count <= optionsFiltering.MaxCount : true) &&

                        (optionsFiltering.Uniqcode != null && optionsFiltering.Uniqcode != "" ? obj.Uniqcode == optionsFiltering.Uniqcode : true)
                     select obj).ToList());

                if (optionsSorting != null)
                {
                    mObject = Sort.Sorting(optionsSorting, mObject).ToList();
                }

                if (optionsPages != null)
                {
                    mObject = Pages.GetPages(optionsPages, mObject).ToList();
                }

                return mObject;

            }
            catch (Exception)
            {
                throw new NotImplementedException();
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
        }
    }
}

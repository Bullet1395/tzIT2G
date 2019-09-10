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
using System.Threading.Tasks;

namespace Models.Services
{
    public class ObjectInventoryService : IObjectInventoryService
    {
        private readonly IRepository<ObjectInventory> db;
        private readonly IRepository<GuidebookTypes> dbGuideBooks;
        private readonly IMapper mapper;

        public ObjectInventoryService(IRepository<ObjectInventory> repository, IRepository<GuidebookTypes> repositoryGuideBooks, IMapper mapperConf)
        {
            db = repository;
            dbGuideBooks = repositoryGuideBooks;
            mapper = mapperConf;
        }

        public IMapper MapperConf { get; }

        public async Task AddObjectInventory(ObjectInventoryDTO newObject)
        {
            if (await dbGuideBooks.Get(newObject.GuidebookType.Id) != null)
            {
                var mObject = mapper.Map<ObjectInventoryDTO, ObjectInventory>(newObject);
                mObject.GuidebookType = await dbGuideBooks.Get(newObject.GuidebookType.Id);
                await db.Create(mObject);
                await db.Save();
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

        public async Task<ObjectInventoryDTO> GetObject(int id)
        {
            var mObject = mapper.Map<ObjectInventory, ObjectInventoryDTO>(await db.Get(id));
            return mObject;
        }

        public IEnumerable<ObjectInventoryDTO> GetObjects(Options configOpt)
        {
            var optionsFiltering = configOpt.OptionsFilter;
            var optionsSorting = configOpt.OptionsSort;
            var optionsPages = configOpt.OptionsPage;

            var mObject = mapper.Map<IEnumerable<ObjectInventory>, List<ObjectInventoryDTO>>(
                (from obj in db.GetAllQuery()
                 where
                 optionsFiltering != null ? (
                    (optionsFiltering.Types != null ? optionsFiltering.Types.Contains(obj.GuidebookType.Id) : true) &&

                    ((optionsFiltering.Names != null || optionsFiltering.Names != "") ? obj.Name.Contains(optionsFiltering.Names) : true) &&

                    ((optionsFiltering.MinCount != null && optionsFiltering.MaxCount != null) ? obj.Count >= optionsFiltering.MinCount && obj.Count <= optionsFiltering.MaxCount :
                        (optionsFiltering.MinCount != null && optionsFiltering.MaxCount == null) ? obj.Count >= optionsFiltering.MinCount :
                            (optionsFiltering.MinCount == null && optionsFiltering.MaxCount != null) ? obj.Count <= optionsFiltering.MaxCount : true) &&

                    (optionsFiltering.Uniqcode != null && optionsFiltering.Uniqcode != "" ? obj.Uniqcode == optionsFiltering.Uniqcode : true)) : true
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

        public void RemoveObject(int id)
        {
            db.Delete(id);
            db.Save();
        }

        public void UpdateObject(ObjectInventoryDTO newObject)
        {
            var mObject = mapper.Map<ObjectInventoryDTO, ObjectInventory>(newObject);
            db.Update(mObject);
            db.Save();
        }
    }
}

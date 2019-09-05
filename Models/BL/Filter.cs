using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models.BL
{

    public class Filter
    {
        public List<int> types { get; set; }
        public string names { get; set; }
        public int? minCount { get; set; } 
        public int? maxCount { get; set; }
        public string uniqcode { get; set; }

        public Filter(List<int> types, string names, int? minCount, int? maxCount, string uniqcode)
        {
            this.types = types;
            this.names = names;
            this.minCount = minCount;
            this.maxCount = maxCount;
            this.uniqcode = this.uniqcode;
        }

        /// <summary>
        /// Применение фильтров к полученному списку
        /// </summary>
        /// <param name="filtres"></param>
        /// <returns></returns>
        public IEnumerable<ObjectInventoryDTO> Filtering(Filter filtres, IEnumerable<ObjectInventoryDTO> objectsInventory)
        {
            return (from obj in objectsInventory
                                 where
                                     filtres.types != null ? filtres.types.Contains(obj.idType) : true &&
                                     (filtres.names != null && filtres.names != "") ? obj.name.Contains(filtres.names) : true &&
                                     ((filtres.minCount != null && filtres.maxCount != null) ? obj.count >= filtres.minCount && obj.count <= filtres.maxCount :
                                        (filtres.minCount != null && filtres.maxCount == null) ? obj.count >= filtres.minCount :
                                            (filtres.minCount == null && filtres.maxCount != null) ? obj.count <= filtres.maxCount : true) &&
                                    filtres.uniqcode != null && filtres.uniqcode != "" ? obj.uniqcode == filtres.uniqcode : true
                                 select obj).ToList();
        }
    }
}

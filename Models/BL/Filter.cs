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
        public List<int> Types { get; set; }
        public string Names { get; set; }
        public int? MinCount { get; set; } 
        public int? MaxCount { get; set; }
        public string Uniqcode { get; set; }

        public Filter(List<int> types, string names, int? minCount, int? maxCount, string uniqcode)
        {
            this.Types = types;
            this.Names = names;
            this.MinCount = minCount;
            this.MaxCount = maxCount;
            this.Uniqcode = this.Uniqcode;
        }

        public Filter()
        {
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
                                     filtres.Types != null ? filtres.Types.Contains(obj.IdType) : true &&
                                     (filtres.Names != null && filtres.Names != "") ? obj.Name.Contains(filtres.Names) : true &&
                                     ((filtres.MinCount != null && filtres.MaxCount != null) ? obj.Count >= filtres.MinCount && obj.Count <= filtres.MaxCount :
                                        (filtres.MinCount != null && filtres.MaxCount == null) ? obj.Count >= filtres.MinCount :
                                            (filtres.MinCount == null && filtres.MaxCount != null) ? obj.Count <= filtres.MaxCount : true) &&
                                    filtres.Uniqcode != null && filtres.Uniqcode != "" ? obj.Uniqcode == filtres.Uniqcode : true
                                 select obj).ToList();
        }
    }
}

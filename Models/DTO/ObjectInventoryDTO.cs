using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ObjectInventoryDTO
    {
        public int Id { get; set; }
        public GuidebookTypesDTO GuidebookType { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Uniqcode { get; set; }
    }
}

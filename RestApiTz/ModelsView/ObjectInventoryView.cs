using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTz.ModelsView
{
    public class ObjectInventoryView
    {
        public int Id { get; set; }
        public int IdType { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string Uniqcode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTz.ModelsView
{
    public class ObjectInventoryView
    {
        public int id { get; set; }
        public int idType { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public string uniqcode { get; set; }
    }
}

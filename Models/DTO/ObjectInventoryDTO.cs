using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ObjectInventoryDTO
    {
        public int id { get; set; }
        public int idType { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public string uniqcode { get; set; }
    }
}

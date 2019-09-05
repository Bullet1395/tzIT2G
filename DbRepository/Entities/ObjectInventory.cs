using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Объект инвентаризации
    /// </summary>
    public class ObjectInventory
    {
        // ID
        public int id { get; set; }

        // ID типа из справочника типов(Guidbooks
        public int idType { get; set; }

        // Наименование
        public string name { get; set; }

        // Количество
        public int? count { get; set; }

        // Штрих-код
        public string uniqcode { get; set; }
    }
}

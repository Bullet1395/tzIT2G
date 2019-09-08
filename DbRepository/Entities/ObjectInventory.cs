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
        public int Id { get; set; }

        // ID типа из справочника типов(Guidbooks
        public int IdType { get; set; }

        // Наименование
        public string Name { get; set; }

        // Количество
        public int Count { get; set; }

        // Штрих-код
        public string Uniqcode { get; set; }
    }
}

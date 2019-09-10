using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Объект инвентаризации
    /// </summary>
    public class ObjectInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // ID
        public int Id { get; set; }

        // ID типа из справочника типов(GuidebooksTypes)
        public GuidebookTypes GuidebookType { get; set; }

        [MaxLength(512)]
        // Наименование
        public string Name { get; set; }

        // Количество
        public int Count { get; set; }

        [MaxLength(256)]
        // Штрих-код
        public string Uniqcode { get; set; }       

    }
}

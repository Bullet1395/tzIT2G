using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    /// <summary>
    /// Справочник типов
    /// </summary>
    public class GuidebookTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // ID
        public int Id { get; set; }

        [MaxLength(256)]
        // Название типа
        public string Name { get; set; }
    }
}

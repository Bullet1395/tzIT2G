using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IGuidBookService
    {
        /// <summary>
        /// Добавить новый тип в справочник
        /// </summary>
        /// <param name="newGuidbook">Новый объект типа</param>
        void AddTypeGuidBook(GuidbookDTO newGuidbook);

        /// <summary>
        /// Получить весь список типов
        /// </summary>
        /// <returns></returns>
        IEnumerable<GuidbookDTO> GetGuidBooks();

        /// <summary>
        /// Получить тип из справочника по его ID
        /// </summary>
        /// <param name="id">ID типа в справочнике</param>
        /// <returns></returns>
        GuidbookDTO GetGuidBook(int id);

        /// <summary>
        /// Обновить тип в справочнике
        /// </summary>
        /// <param name="newGuidBook">Объект для обновления</param>
        void UpdateGuidBook(GuidbookDTO newGuidBook);

        /// <summary>
        /// Удаления типа из справочника по его ID
        /// </summary>
        /// <param name="id">ID для удаления</param>
        void RemoveGuidBook(int id);

    }
}

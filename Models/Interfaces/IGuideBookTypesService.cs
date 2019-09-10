using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IGuideBookTypesService
    {
        /// <summary>
        /// Добавить новый тип в справочник
        /// </summary>
        /// <param name="newGuidebookType">Новый объект типа</param>
        Task AddTypeGuideBookType(GuidebookTypesDTO newGuidebookType);

        /// <summary>
        /// Получить весь список типов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GuidebookTypesDTO>> GetGuideBookTypes();

        /// <summary>
        /// Получить тип из справочника по его ID
        /// </summary>
        /// <param name="id">ID типа в справочнике</param>
        /// <returns></returns>
        Task<GuidebookTypesDTO> GetGuideBookType(int id);

        /// <summary>
        /// Обновить тип в справочнике
        /// </summary>
        /// <param name="newGuideBookType">Объект для обновления</param>
        void UpdateGuideBookType(GuidebookTypesDTO newGuideBookType);

        /// <summary>
        /// Удаления типа из справочника по его ID
        /// </summary>
        /// <param name="id">ID для удаления</param>
        void RemoveGuideBookType(int id);

    }
}

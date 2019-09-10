using DTO;
using Models.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IObjectInventoryService
    {
        /// <summary>
        /// Добавить объект инвентаризации
        /// </summary
        Task AddObjectInventory(ObjectInventoryDTO newObject);

        /// <summary>
        /// Получить пример конфигурации для фильтрации/сортировки/постраничного вывода списка
        /// </summary>
        /// <param name="optionsFiltering">Опции для фильтрации</param>
        /// <param name="optionsSorting">Опции для сортировки</param>
        /// <param name="optionsPages">Опции для постраничного вывода</param>
        /// <returns></returns>
        Options GetExampleOptions();

        /// <summary>
        /// Получить объект по его ID
        /// </summary>
        /// <param name="id">ID объекта для поиска</param>
        /// <returns></returns>
        Task<ObjectInventoryDTO> GetObject(int id);

        /// <summary>
        /// Получить отфильтрованный/отсротированный/постраничный список объектов инвентаризации
        /// </summary>
        /// <param name="configOpt">КОнфигурация настроек для фильтрации/сортировки/постраничного вывода</param>
        /// <returns></returns>
        IEnumerable<ObjectInventoryDTO> GetObjects(Options configOpt);

        /// <summary>
        /// Оббновление объекта инвентаризации
        /// </summary>
        /// <param name="newObject">Объект инвентаризации</param>
        void UpdateObject(ObjectInventoryDTO newObject);

        /// <summary>
        /// Удалить объект инвентаризации по его ID
        /// </summary>
        /// <param name="id">ID для удаления</param>
        void RemoveObject(int id);
    }
}

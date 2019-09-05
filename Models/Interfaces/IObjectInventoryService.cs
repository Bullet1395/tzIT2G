using DTO;
using Models.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IObjectInventoryService
    {
        /// <summary>
        /// Добавить объект инвентаризации
        /// </summary
        void AddObjectInventory(ObjectInventoryDTO newObject);

        /// <summary>
        /// Получить отфильтрованный/отсротированный/постраничный список объектов инвентаризации
        /// </summary>
        /// <param name="optionsFiltering">Опции для фильтрации</param>
        /// <param name="optionsSorting">Опции для сортировки</param>
        /// <param name="optionsPages">Опции для постраничного вывода</param>
        /// <returns></returns>
        IEnumerable<ObjectInventoryDTO> GetObjects(Filter optionsFiltering, Sort[] optionsSorting, Pages optionsPages);

        /// <summary>
        /// Получить объект иневнтаризации по его ID
        /// </summary>
        /// <param name="id">ID объекта</param>
        /// <returns></returns>
        ObjectInventoryDTO GetObject(int id);

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

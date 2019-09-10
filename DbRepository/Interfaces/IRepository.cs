using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRepository.Interfaces
{

    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Получение всех объектов(IQueryable)
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAllQuery();

        /// <summary>
        /// Получение всех объектов
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Получение объекта по его ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> Get(int id); 
        
        /// <summary>
        /// Создать объект
        /// </summary>
        /// <param name="item"></param>
        Task Create(T item);
        
        /// <summary>
        /// Обновить объект
        /// </summary>
        /// <param name="item"></param>
        void Update(T item); 
        
        /// <summary>
        /// Удалить объект по его ID
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id); 
        
        /// <summary>
        /// Сохранить изменения
        /// </summary>
        Task Save();  
    }
}

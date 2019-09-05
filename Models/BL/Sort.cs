using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Models.BL
{    
    public class Sort
    {
        public string property { get; set; }
        public string direction { get; set; }

        public Sort(string property, string direction)
        {
            this.property = property;
            this.direction = direction;
        }

        public Sort()
        {
        }

        /// <summary>
        /// Сортировка полученного списка
        /// </summary>
        /// <param name="sort">Параметры сортировки [название параметра, Asc или Desc] </param>
        /// <param name="listForSort">Лист для сортировки</param>
        /// <returns></returns>
        public static IEnumerable<ObjectInventoryDTO> Sorting(Sort[] sort, IEnumerable<ObjectInventoryDTO> listForSort)
        {
            IOrderedEnumerable<ObjectInventoryDTO> temp = null;

            foreach (var s in sort)
            {
                Func<ObjectInventoryDTO, IComparable> keySelector = GetKeySelector<ObjectInventoryDTO>(s.property);

                if (temp == null)
                {
                    temp = s.direction == "Asc" ?
                            listForSort.OrderBy(keySelector) :
                            listForSort.OrderByDescending(keySelector);
                }
                else
                {
                    temp = s.direction == "Asc" ?
                            temp.ThenBy(keySelector) :
                            temp.ThenByDescending(keySelector);
                }
            }

            return temp ?? listForSort;
        }

        private static Func<T, IComparable> GetKeySelector<T>(string property)
        {
            var param = Expression.Parameter(typeof(T));
            var lambda = Expression.Lambda<Func<T, IComparable>>(
                Expression.Convert(
                    Expression.Property(param, property),
                    typeof(IComparable)),
                param);
            return lambda.Compile();
        }
    }
}

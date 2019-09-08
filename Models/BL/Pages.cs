using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.PagedList;


namespace Models.BL
{
    public class Pages
    {
        public int CountOnPage { get; set; }
        public int NumberPage { get; set; }

        public Pages(int countOnPage, int numberPage)
        {
            this.CountOnPage = countOnPage;
            this.NumberPage = numberPage;
        }

        public Pages()
        {
        }

        /// <summary>
        /// Получение постраничного списка
        /// </summary>
        /// <param name="optionsPages"></param>
        /// <param name="listObjects"></param>
        /// <returns></returns>
        public static IEnumerable<ObjectInventoryDTO> GetPages(Pages optionsPages, IEnumerable<ObjectInventoryDTO> listObjects)
        {            
            if (listObjects.Count()/optionsPages.CountOnPage >= optionsPages.NumberPage)
            {
                var pagedList = listObjects.ToPagedList(optionsPages.NumberPage, optionsPages.CountOnPage);

                return pagedList;
            } else
            {
                var pagedList = listObjects.ToPagedList(1, optionsPages.CountOnPage);

                return pagedList;
            }

        }

    }
}

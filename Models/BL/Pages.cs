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
        public int countOnPage { get; set; }
        public int numberPage { get; set; }

        public Pages(int countOnPage, int numberPage)
        {
            this.countOnPage = countOnPage;
            this.numberPage = numberPage;
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
            if (listObjects.Count()/optionsPages.countOnPage >= optionsPages.numberPage)
            {
                var pagedList = listObjects.ToPagedList(optionsPages.numberPage, optionsPages.countOnPage);

                return pagedList;
            } else
            {
                var pagedList = listObjects.ToPagedList(1, optionsPages.countOnPage);

                return pagedList;
            }

        }

    }
}

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

        /// <summary>
        /// Получение постраничного списка
        /// </summary>
        /// <param name="optionsPages"></param>
        /// <param name="listGuidbooks"></param>
        /// <returns></returns>
        public static IEnumerable<GuidbookDTO> GetPages(Pages optionsPages, IEnumerable<GuidbookDTO> listGuidbooks)
        {
            
            if (listGuidbooks.Count()/optionsPages.countOnPage >= optionsPages.numberPage)
            {
                var pagedList = listGuidbooks.ToPagedList(optionsPages.numberPage, optionsPages.countOnPage);

                return pagedList;
            } else
            {
                return null;
            }

        }

    }
}

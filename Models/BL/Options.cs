using System;
using System.Collections.Generic;
using System.Text;

namespace Models.BL
{
    public class Options
    {
        public Filter optionsFilter { get; set; }
        public Sort[] optionsSort { get; set; }
        public Pages optionsPage { get; set; }

        public Options(Filter optionsFilter, Sort[] optionsSort, Pages optionsPage)
        {
            this.optionsFilter = optionsFilter;
            this.optionsSort = optionsSort;
            this.optionsPage = optionsPage;
        }

        public Options()
        {
        }
    }
}

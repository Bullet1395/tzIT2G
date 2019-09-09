using System;
using System.Collections.Generic;
using System.Text;

namespace Models.BL
{
    public class Options
    {
        public Filter OptionsFilter { get; set; }
        public Sort[] OptionsSort { get; set; }
        public Pages OptionsPage { get; set; }

        public Options(Filter optionsFilter, Sort[] optionsSort, Pages optionsPage)
        {
            this.OptionsFilter = optionsFilter;
            this.OptionsSort = optionsSort;
            this.OptionsPage = optionsPage;
        }

        public Options()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class Factory
    {
        private static Factory instance = new Factory();
        private Factory() { }
        public static Factory Instance
        {
            get { return instance; }
        }

        public AccountRepository accountRepository = new AccountRepository();
        public SeriesRepository seriesRepository = new SeriesRepository();
        public MovieRepository movieRepository = new MovieRepository();

        
    }
}

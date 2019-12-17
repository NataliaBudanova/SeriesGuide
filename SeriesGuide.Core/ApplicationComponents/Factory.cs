using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class Factory
    {
        private Factory() { }
        public static Factory Instance { get; } = new Factory();

        public AccountRepository accountRepository = new AccountRepository();
        public SeriesRepository seriesRepository = new SeriesRepository();
        public MovieRepository movieRepository = new MovieRepository();

        
    }
}

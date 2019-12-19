using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class Factory
    {
        private static Factory instance = new Factory();
        private Factory() 
        {
            accountRepository = new AccountRepository();
            seriesRepository = new SeriesRepository();
            filmRepository = new FilmRepository();
        }
        public static Factory Instance { get { return instance; } } 

        public AccountRepository accountRepository { get; set; }
        public SeriesRepository seriesRepository { get; set; }
        public FilmRepository filmRepository { get; set; }
}
}

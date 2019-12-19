using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class SeriesRepository
    {
        private List<Series> items;
        private List<Series> recentSeries;
        public IEnumerable<Series> Items => items;

        public IEnumerable<Series> RecentSeries => recentSeries;

        public SeriesRepository()
        {
            items = JsonConvertor.UpLoad<List<Series>>(Path.Combine(FolderPath, FileName));
            recentSeries = items.Where(s => ((DateTime.Now).Year - s.ReleaseYear <= 20)).ToList();
        }

        private const string FileName = "SeriesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

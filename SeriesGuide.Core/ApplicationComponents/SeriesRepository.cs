using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> items;
        private List<Series> resentSeries;
        public IEnumerable<Series> Items => items;

        public IEnumerable<Series> ResentSeries => resentSeries;

        public SeriesRepository()
        {
            items = JsonConvertor.UpLoad<List<Series>>(Path.Combine(FolderPath, FileName));
            resentSeries = items.Where(s => ((DateTime.Now).Year - s.ReleaseYear <= 20)).ToList();
        }

        public void Add(Series item)
        {
            items.Add(item);
        }

        private const string FileName = "SeriesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

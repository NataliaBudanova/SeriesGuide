using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> items;
        public IEnumerable<Series> Items => items;

        public SeriesRepository()
        {
            items = JsonConvertor.UpLoad<List<Series>>(Path.Combine(FolderPath, FileName));
        }

        public void Add(Series item)
        {
            items.Add(item);
        }

        private const string FileName = "TVSeriesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

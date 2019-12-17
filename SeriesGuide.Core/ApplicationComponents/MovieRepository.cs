using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class MovieRepository : IRepository<Film>
    {
        private List<Film> items;
        public IEnumerable<Film> Items => items;

        public MovieRepository()
        {
            items = JsonConvertor.UpLoad<List<Film>>(Path.Combine(FolderPath, FileName));
        }

        public void Add(Film item)
        {
            items.Add(item);
        }

        private const string FileName = "FilmsData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

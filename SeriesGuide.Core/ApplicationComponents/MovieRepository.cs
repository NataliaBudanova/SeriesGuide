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

        public MovieRepository(IJsonConvertor convertor)
        {
            items = convertor.UpLoad<List<Film>>(Path.Combine(FolderPath, FileName));
        }

        public void Add(Film item)
        {
            items.Add(item);
        }

        private const string FileName = "MoviesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

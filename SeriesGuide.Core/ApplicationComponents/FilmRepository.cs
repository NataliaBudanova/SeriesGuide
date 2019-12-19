﻿using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class FilmRepository : IRepository<Film>
    {
        private List<Film> items;
        private List<Film> reсentFilms;
        public IEnumerable<Film> Items => items;
        public IEnumerable<Film> ReсentFilms => reсentFilms;

        public FilmRepository()
        {
            items = JsonConvertor.UpLoad<List<Film>>(Path.Combine(FolderPath, FileName));
            reсentFilms = items.Where(f => ((DateTime.Now).Year - f.ReleaseYear <= 20)).ToList();
        }

        public void Add(Film item)
        {
            items.Add(item);
        }

        public void UdateFilm(Film film)
        {

        }

        private const string FileName = "FilmsData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

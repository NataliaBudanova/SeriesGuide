using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class FilmRepository
    {
        private List<Film> items;
        private List<Film> reсentFilms;
        private Dictionary<int, List<Review>> reviews;
        public IDictionary<int, List<Review>> Reviews => reviews;
        public IEnumerable<Film> Items => items;
        public IEnumerable<Film> ReсentFilms => reсentFilms;

        public FilmRepository()
        {
            reviews = JsonConvertor.UpLoad<Dictionary<int, List<Review>>>(Path.Combine(FolderPath, ReviewsFileName));
            items = JsonConvertor.UpLoad<List<Film>>(Path.Combine(FolderPath, FilmFileName));
            reсentFilms = items.Where(f => ((DateTime.Now).Year - f.ReleaseYear <= 1)).ToList();
        }

        public void UpdateReviews(int seriesId, Review review)
        {
            reviews[seriesId].Add(review);
            JsonConvertor.Save<Dictionary<int, List<Review>>>(reviews, Path.Combine(FolderPath, ReviewsFileName));
        }

        public void AddFilm(Film film)
        {
            items.Add(film);
            reviews[film.Id] = new List<Review>();
            JsonConvertor.Save<List<Film>>(items, Path.Combine(FolderPath, FilmFileName));
            JsonConvertor.Save<Dictionary<int, List<Review>>>(reviews, Path.Combine(FolderPath, ReviewsFileName));
        }


        private const string FilmFileName = "FilmsData.json";
        private const string ReviewsFileName = "FilmReviews.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

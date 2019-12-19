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
        public IEnumerable<Film> Items => items;
        public IEnumerable<Film> ReсentFilms => reсentFilms;

        public FilmRepository()
        {
            items = JsonConvertor.UpLoad<List<Film>>(Path.Combine(FolderPath, FileName));
            reсentFilms = items.Where(f => ((DateTime.Now).Year - f.ReleaseYear <= 20)).ToList();
        }

        public void UdateFilm(Film film)
        {
            items.Remove(items.First(f => f.Id == film.Id));
            items.Add(film);
            if (Factory.Instance.accountRepository.CurrentAccount.Watched.Any(f => f.Id == film.Id))
                Factory.Instance.accountRepository.CurrentAccount.Watched
                    .Remove(Factory.Instance.accountRepository.CurrentAccount.Watched.First(f => f.Id == film.Id));
            if (Factory.Instance.accountRepository.CurrentAccount.WatchList.Any(f => f.Id == film.Id))
                Factory.Instance.accountRepository.CurrentAccount.WatchList
                    .Remove(Factory.Instance.accountRepository.CurrentAccount.Watched.First(f => f.Id == film.Id));
            Factory.Instance.accountRepository.Items.Where(a => a.Watched.Any(f => f.Id == film.Id) || a.WatchList.Any(f => f.Id == film.Id))

        }

        private const string FileName = "FilmsData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        private Dictionary<int, List<Episode>> added = new Dictionary<int, List<Episode>>();
        public IDictionary<int, List<Episode>> Added => added;

        private List<Film> toWatchList = new List<Film>();
        public IEnumerable<object> ToWatchList => toWatchList;

        private List<Film> watchedList = new List<Film>();
        public IEnumerable<Film> WatchedList => watchedList;

        public void AddEpisode(int idSerie,Episode episode)
        {
            if (added.ContainsKey(idSerie))
                added[idSerie].Add(episode);
            else
                added[idSerie] = new List<Episode> { episode };
        }

        public void RemoveEpisode(int idSerie, Episode episode)
        {
            added[idSerie].Remove(episode);
            if (added[idSerie].Count == 0)
                added.Remove(idSerie);
        }
        public void AddToWatchList(Film film)
        {
            toWatchList.Add(film);
        }
        public void RemoveFromToWatchList(Film film)
        {
            toWatchList.Remove(film);
        }

        public void AddToWatchedList(Film film)
        {
            watchedList.Add(film);
        }
        public void RemoveFromWatchedList(Film film)
        {
            watchedList.Remove(film);
        }
    }
}

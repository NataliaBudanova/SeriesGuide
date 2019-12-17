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

        public Dictionary<int, List<Episode>> Added = new Dictionary<int, List<Episode>>();

        private List<Film> ToWatchList = new List<Film>();

        private List<Film> WatchedList = new List<Film>();

        public void AddEpisode(int idSerie,Episode episode)
        {
            if (Added.ContainsKey(idSerie))
                Added[idSerie].Add(episode);
            else
                Added[idSerie] = new List<Episode> { episode };
        }

        public void RemoveEpisode(int idSerie, Episode episode)
        {
            Added[idSerie].Remove(episode);
            if (Added[idSerie].Count == 0)
                Added.Remove(idSerie);
        }
        public void AddToWatchList(Film film)
        {
            ToWatchList.Add(film);
        }
        public void RemoveFromToWatchList(Film film)
        {
            ToWatchList.Remove(film);
        }

        public void AddToWatchedList(Film film)
        {
            WatchedList.Add(film);
        }
        public void RemoveFromWatchedList(Film film)
        {
            WatchedList.Remove(film);
        }
    }
}

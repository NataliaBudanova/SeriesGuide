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

        private List<Film> watchList = new List<Film>();

        private List<Film> watched = new List<Film>();

        public IEnumerable<Film> WatchList => watchList;
        public IEnumerable<Film> Watched => watched;
        public Account(int id, string login, string phoneNumber, string password)
        {
            Id = id;
            Login = login;
            PhoneNumber = phoneNumber;
            Password = password;
        }

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
            watchList.Add(film);
        }
        public void RemoveFromToWatchList(Film film)
        {
            watchList.Remove(film);
        }

        public void AddToWatched(Film film)
        {
            watched.Add(film);
        }
        public void RemoveFromWatched(Film film)
        {
            watched.Remove(film);
        }
    }
}

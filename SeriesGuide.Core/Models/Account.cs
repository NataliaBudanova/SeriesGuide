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

        private List<Film> toWatchList = new List<Film>();

        private List<Film> watchedList = new List<Film>();

        public IEnumerable<Film> ToWatchList => toWatchList;
        public IEnumerable<Film> WatchedList => watchedList;
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

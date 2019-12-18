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

        public List<Film> WatchList { get; }
        public List<Film> Watched { get; }

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
                if(!Added[idSerie].Contains(episode))
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
            if (!WatchList.Contains(film))
                WatchList.Add(film);
        }
        public void RemoveFromToWatchList(Film film)
        {
            if(WatchList.Contains(film))
                WatchList.Remove(film);
        }

        public void AddToWatched(Film film)
        {
            if(!Watched.Contains(film))
                Watched.Add(film);
        }
        public void RemoveFromWatched(Film film)
        {
            if(Watched.Contains(film))
            Watched.Remove(film);
        }
    }
}

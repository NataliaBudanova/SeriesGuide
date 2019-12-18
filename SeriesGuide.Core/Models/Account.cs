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

        public List<Film> watchList { get; }
        public List<Film> watched { get; }

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
            if (!watchList.Contains(film))
                watchList.Add(film);
        }
        public void RemoveFromToWatchList(Film film)
        {
            if(watchList.Contains(film))
                watchList.Remove(film);
        }

        public void AddToWatched(Film film)
        {
            if(!watched.Contains(film))
                watched.Add(film);
        }
        public void RemoveFromWatched(Film film)
        {
            if(watched.Contains(film))
            watched.Remove(film);
        }
    }
}

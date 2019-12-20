using SeriesGuide.Core.ApplicationComponents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public Dictionary<int, List<int>> Added { get; set; }
        public List<int> AddedSeries { get; set; }
        public List<int> WatchList { get; set; }
        public List<int> Watched { get; set; }

        public Account(int id, string login, string phoneNumber, string password)
        {
            Id = id;
            Login = login;
            PhoneNumber = phoneNumber;
            Password = password;
            AddedSeries = new List<int>();
            WatchList = new List<int>();
            Watched = new List<int>();
            FullfillAdded();
        }

        private void FullfillAdded()
        {
            List<Series> _series = JsonConvertor.UpLoad<List<Series>>(Path.Combine(FolderPath, SeriesFileName));
            foreach (Series series in _series)
            {
                Added = new Dictionary<int, List<int>>();
                if (!Added.ContainsKey(series.Id))
                {
                    Added.Add(series.Id, new List<int>());
                }
            }
        }

        public void AddSeries(Series series)
        {
            if (!AddedSeries.Contains(series.Id))
            {
                AddedSeries.Add(series.Id);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }

        public void RemoveFromAddedSeries(Series series)
        {
            if (AddedSeries.Contains(series.Id))
            {
                AddedSeries.Remove(series.Id);
                Added[series.Id] = new List<int>();
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }

        public void AddEpisode(int seriesId, Episode episode)
        {
            if (!Added[seriesId].Contains(episode.EpisodeID))
            {
                Added[seriesId].Add(episode.EpisodeID);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }     

        public void RemoveEpisode(int seriesId, Episode episode)
        {
            if (Added.ContainsKey(seriesId))
            {
                Added[seriesId].Remove(episode.EpisodeID);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }
        public void AddToWatchList(Film film)
        {
            if (!WatchList.Contains(film.Id))
            {
                WatchList.Add(film.Id);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
               
        }
        public void RemoveFromWatchList(Film film)
        {
            if(WatchList.Contains(film.Id))
            {
                WatchList.Remove(film.Id);
                Factory.Instance.accountRepository.UpdateAccount(Id); 
            }
                
        }

        public void AddToWatched(Film film)
        {
            if (!Watched.Contains(film.Id))
            {
                Watched.Add(film.Id);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
                
        }
        public void RemoveFromWatched(Film film)
        {
            if (Watched.Contains(film.Id))
            {
                Watched.Remove(film.Id);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
            
        }
        private const string SeriesFileName = "SeriesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

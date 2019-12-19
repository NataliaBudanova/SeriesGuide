﻿using SeriesGuide.Core.ApplicationComponents;
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

        public Dictionary<int, List<Episode>> Added { get; set; }
        public List<Series> AddedSeries { get; set; }
        public List<Film> WatchList { get; set; }
        public List<Film> Watched { get; set; }

        public Account(int id, string login, string phoneNumber, string password)
        {
            Id = id;
            Login = login;
            PhoneNumber = phoneNumber;
            Password = password;
            AddedSeries = new List<Series>();
            WatchList = new List<Film>();
            Watched = new List<Film>();
            FullfillAdded();
        }

        private void FullfillAdded()
        {
            List<int> seriesIds = JsonConvertor.UpLoad<List<Series>>(Path.Combine(FolderPath,SeriesFileName)).Select(s => s.Id).ToList();
            foreach (int id in seriesIds)
            {
                Added = new Dictionary<int, List<Episode>>();
                if (!Added.ContainsKey(id))
                {
                    Added.Add(id, new List<Episode>());
                }
            }
        }

        public void AddSeries(Series series)
        {
            if (!AddedSeries.Contains(series))
            {
                AddedSeries.Add(series);
                Added.Add(series.Id, new List<Episode>());
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }

        public void RemoveFromAddedSeries(Series series)
        {
            if (AddedSeries.Contains(series))
            {
                AddedSeries.Remove(series);
                Added[series.Id] = new List<Episode>();
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }

        public void AddEpisode(int idSerie,Episode episode)
        {
            if (!Added.ContainsKey(idSerie))
            {
                Added[idSerie] = new List<Episode> { episode };
                AddedSeries.Add(Factory.Instance.seriesRepository.Items.First(s => s.Id == idSerie));
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }  
            else if (!Added[idSerie].Contains(episode))
                 {
                    Added[idSerie].Add(episode);
                    Factory.Instance.accountRepository.UpdateAccount(Id);
                 }          
        }

        public void RemoveEpisode(int idSerie, Episode episode)
        {
            if (Added.ContainsKey(idSerie))
            {
                Added[idSerie].Remove(episode);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
        }
        public void AddToWatchList(Film film)
        {
            if (!WatchList.Contains(film))
            {
                WatchList.Add(film);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
               
        }
        public void RemoveFromWatchList(Film film)
        {
            if(WatchList.Contains(film))
            {
                WatchList.Remove(film);
                Factory.Instance.accountRepository.UpdateAccount(Id); 
            }
                
        }

        public void AddToWatched(Film film)
        {
            if (!Watched.Contains(film))
            {
                Watched.Add(film);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
                
        }
        public void RemoveFromWatched(Film film)
        {
            if (Watched.Contains(film))
            {
                Watched.Remove(film);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }
            
        }
        private const string SeriesFileName = "SeriesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

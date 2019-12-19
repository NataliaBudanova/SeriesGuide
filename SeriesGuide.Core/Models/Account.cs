﻿using SeriesGuide.Core.ApplicationComponents;
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

        public List<Film> WatchList { get; set; }
        public List<Film> Watched { get; set; }

        public Account(int id, string login, string phoneNumber, string password)
        {
            Id = id;
            Login = login;
            PhoneNumber = phoneNumber;
            Password = password;
        }
        public void AddSeries(Series series)
        {
            if(Added)
        }

        public void AddEpisode(int idSerie,Episode episode)
        {
            if (Added.ContainsKey(idSerie))
            {
                Added[idSerie].Add(episode);
                Factory.Instance.accountRepository.UpdateAccount(Id);
            }  
            else if (!Added[idSerie].Contains(episode))
                 {
                     Added[idSerie] = new List<Episode> { episode };
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
                
            if (Added[idSerie].Count == 0)
            {
                Added.Remove(idSerie);
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
        public void RemoveFromToWatchList(Film film)
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
    }
}

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
        private List<Film> toWatchList = new List<Film>();
        public IEnumerable<object> ToWatchList => toWatchList;

        private List<Film> watchedList = new List<Film>();
        public IEnumerable<Film> WatchedList => watchedList;
    }
}

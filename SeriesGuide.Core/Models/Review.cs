using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Review
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int AccountId { get; set; }
        public string Login { get; set; }

        public Review(int rating, string comment, int accountId, string login)
        {
            Rating = rating;
            Comment = comment;
            AccountId = accountId;
            Login = login;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public abstract class VideoContent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public List<Review> Reviews { get; set; }
        public string Directors { get; set; }
        public string Countries { get; set; }
        public List<string> Actors { get; set; }
        public string Description { get; set; }
        public bool IfReviewAvailable(int id)
        {
            return !Reviews.Any(r => r.AccountId == id);
        }
        public decimal GetTotalRating()
        {
            if (Reviews.Count() != 0)
                return Reviews.Sum(r => r.Rating) / Reviews.Count();
            else
                return 0;
        }
    }
}

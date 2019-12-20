using SeriesGuide.Core.ApplicationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Series : VideoContent
    {
        public int? EndYear { get; set; }
        public bool IsEnded { get; set; }
        public int NumberOfSeasons { get; set; }

        public List<Episode> Episodes;

        public Series(string name, string genre, List<string> actors, string directors, string countries, string description, List<Episode> episodes, string endYear, int releaseYear)
        {
            Name = name;
            Genre = genre;
            Actors = actors;
            Directors = directors;
            Countries = countries;
            Description = description;
            Episodes = episodes;
            ReleaseYear = releaseYear;
            if (endYear == "")
            {
                EndYear = null;
                IsEnded = false;
            }
            else
            {
                EndYear = int.Parse(endYear);
                IsEnded = true;
            }   
            Id = Factory.Instance.seriesRepository.Items.Count();

        }
        public bool AddReview(Review review)
        {
            if (IfReviewAvailable(review.AccountId))
            {
                Factory.Instance.seriesRepository.UpdateReviews(Id, review);
                return true;
            }
            return false;
        }

        public decimal GetTotalRating()
        {
            var reviews = Factory.Instance.seriesRepository.Reviews;
            if (reviews.ContainsKey(Id))
            {
                if (reviews[Id].Count() != 0)
                    return reviews[Id].Sum(r => r.Rating) / reviews[Id].Count();
                else
                    return 0;
            }
            else
                return 0;
        }

        private bool IfReviewAvailable(int id)
        {
            return !Factory.Instance.seriesRepository.Reviews[Id].Any(r => r.AccountId == id);
        }
    }
}

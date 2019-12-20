using SeriesGuide.Core.ApplicationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Film : VideoContent
    {
        public Film(string name, string genre, List<string> actors, string directors, string countries, string description , int releaseYear)
        {
            Name = name;
            Genre = genre;
            Actors = actors;
            Directors = directors;
            Countries = countries;
            Description = description;
            ReleaseYear = releaseYear;
            try
            {
                Id = Factory.Instance.seriesRepository.Items.Count();
            }
            catch
            {
            }

        }
        public bool AddReview(Review review)
        {
            if (IfReviewAvailable(review.AccountId))
            {
                Factory.Instance.filmRepository.UpdateReviews(Id, review);
                return true;
            }
            return false;
                
        }

        public decimal GetTotalRating()
        {
            var reviews = Factory.Instance.filmRepository.Reviews;
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
            return !Factory.Instance.filmRepository.Reviews[Id].Any(r => r.AccountId == id);
        }
    }
}
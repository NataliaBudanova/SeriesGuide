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
            if (reviews[Id].Count() != 0)
                return reviews[Id].Sum(r => r.Rating) / reviews[Id].Count();
            else
                return 0;
        }

        private bool IfReviewAvailable(int id)
        {
            return !Factory.Instance.seriesRepository.Reviews[Id].Any(r => r.AccountId == id);
        }
    }
}

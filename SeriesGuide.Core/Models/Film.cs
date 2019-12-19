using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Film : VideoContent
    {
        public void AddReview(Review review)
        {
            Reviews.Add(review);

        }
    }
}
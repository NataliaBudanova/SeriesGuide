using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class SeriesRepository
    {
        private List<Series> items;
        private List<Series> recentSeries;
        private Dictionary<int, List<Review>> reviews;
        public IDictionary<int, List<Review>> Reviews => reviews;
        public IEnumerable<Series> Items => items;

        public IEnumerable<Series> RecentSeries => recentSeries;

        public SeriesRepository()
        {
            reviews = JsonConvertor.UpLoad<Dictionary<int, List<Review>>>(Path.Combine(FolderPath, ReviewsFileName));
            items = JsonConvertor.UpLoad<List<Series>>(Path.Combine(FolderPath, SeriesFileName));
            recentSeries = items.Where(s => ((DateTime.Now).Year - s.ReleaseYear <= 20)).ToList();
        }

        public void UpdateReviews(int seriesId, Review review)
        {
            reviews[seriesId].Add(review);
            JsonConvertor.Save<Dictionary<int, List<Review>>>(reviews, Path.Combine(FolderPath, ReviewsFileName));
        }

        
        private const string ReviewsFileName = "SeriesReviews.json";
        private const string SeriesFileName = "SeriesData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

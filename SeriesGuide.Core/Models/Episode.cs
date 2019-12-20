using SeriesGuide.Core.ApplicationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Episode
    {
        public int EpisodeID { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Episode(int seasonNumber, int episodeNumber, string name, string description)
        {
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            Name = name;
            Description = description;
            if (Factory.Instance.seriesRepository.Items.Count() > 0)
                EpisodeID = Factory.Instance.seriesRepository.Items.First(s => s.Id == Factory.Instance.seriesRepository.Items.Max(s => s.Id)).Episodes.Max(e => e.EpisodeID) + episodeNumber;
            else
                EpisodeID = episodeNumber - 1;
        }
    }
}

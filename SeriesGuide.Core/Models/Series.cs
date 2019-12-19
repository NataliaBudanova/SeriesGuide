using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Series : VideoContent
    {
        public int? EndYear { get; set; }
        public bool IsEnded { get; set; }
        public int NumberOfSeasons { get; set; }

        public List<Episode> Episodes;

        public Dictionary<int, List<int>> Added = new Dictionary<int, List<int>>();  // key - series id, in list - Watched episodes IDs
    }
}

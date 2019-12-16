using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Series : VideoContent
    {
        public int SeriesID { get; set; }
        
        private List<Episode> episodes;
        public IEnumerable<Episode> Episodes => episodes;

        private Dictionary <int, List<int>> added = new Dictionary<int, List<int>>();
        public IDictionary<int, List<int>> Added => added; // key - series id, in list - watched episodes IDs
        public bool IsEnded { get; set; }
        public int NumberOfSeasons { get; set; }
    }
}

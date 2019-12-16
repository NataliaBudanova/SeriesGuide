using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Series : VideoContent
    {
        private List<Episode> episodes;
        public IEnumerable<Episode> Episodes => episodes;

        private Dictionary<string, List<int>> added = new Dictionary<string, List<int>>();
        public IDictionary<string, List<int>> Added => added; // key - series Name, in list - watched episodes IDs
        public bool IsEnded { get; set; }
        public int NumberOfSeasons { get; set; }
    }
}

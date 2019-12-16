using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public class Series : VideoContent
    {
        private List<Episode> episodes;
        public IEnumerable<Episode> Episodes => episodes;
    }
}

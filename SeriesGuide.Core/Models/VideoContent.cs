using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public abstract class VideoContent
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Review> Reviews { get; set; }
        public string Director { get; set; }
        public string ProductionCompany { get; set; }
        public double Rating { get; set; }
        public List<string> Actors { get; set; }
    }
}

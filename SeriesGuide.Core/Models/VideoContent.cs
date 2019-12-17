using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesGuide.Core.Models
{
    public abstract class VideoContent
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public List<Review> Reviews { get; set; }
        public string Directors { get; set; }
        public string Countries { get; set; }
        public double Rating { get; set; }
        public List<string> Actors { get; set; }
        public string Description { get; set; }
    }
}

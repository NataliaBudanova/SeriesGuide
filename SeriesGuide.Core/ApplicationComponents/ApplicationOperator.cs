using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class ApplicationOperator
    {
        public static bool AddFilm(string name, string genre, List<string> actors, string directors, string countries, string description, int releaseYear)
        {
            if (Factory.Instance.filmRepository.Items.Any(f => f.Name == name && f.Actors == actors && f.Genre == genre && f.Directors == directors && f.Countries == countries))
            {
                return false;
            }
            else
            {
                Factory.Instance.filmRepository.AddFilm(new Film(name: name, genre: genre,actors:actors, directors:directors,countries:countries,description:description, releaseYear: releaseYear));
                return true;
            }
        }

        public static bool AddSeries(string name, string genre, List<string> actors, string directors, string countries, string description, List<Episode> episodes, string endYear, int releaseYear, int numberOfSeasons)
        {
            if (Factory.Instance.seriesRepository.Items.Any(f => f.Name == name && f.Actors == actors && f.Genre == genre && f.Directors == directors && f.Countries == countries && f.NumberOfSeasons == numberOfSeasons))
            {
                return false;
            }
            else
            {
                Factory.Instance.seriesRepository.AddSeries(new Series(name: name, genre: genre, actors: actors, directors: directors, countries: countries, description: description, episodes:episodes,endYear:endYear,releaseYear:releaseYear, nubmerOfSeasons:numberOfSeasons));
                return true;
            }
        }

        public static string AddActors(string name, string character)
        {
            return $"{name} - {character}";
        }

        public static Episode AddEpisode(int seasonNumber, int episodeNumber, string name, string description)
        {
            return new Episode(seasonNumber: seasonNumber, episodeNumber: episodeNumber, description: description, name: name);
        }
    }
}

using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OwnerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> seriesActors = new List<string>();
        List<string> filmActors = new List<string>();
        List<Episode> episodes = new List<Episode>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SeriesAddActor_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SeriesActor.Text != null & SeriesRole.Text != null)
            {
                seriesActors.Add(ApplicationOperator.AddActors(SeriesActor.Text, SeriesRole.Text));
                SeriesActor.Text = "";
                SeriesRole.Text = "";
            }
            else
            {
                MessageBox.Show("Actor or role field can't be empty");
            }
        }

        private void SeriesAddEpisode_Button_Click(object sender, RoutedEventArgs e)
        {
            if (EpisodeSeasonNumber.Text != null & EpisodeNumber.Text != null & EpisodeName.Text != null)
            {
                if (Int32.TryParse(EpisodeSeasonNumber.Text, out int seasonNumber) & Int32.TryParse(EpisodeNumber.Text, out int episodeNumber))
                {
                    episodes.Add(ApplicationOperator.AddEpisode(seasonNumber, episodeNumber, EpisodeName.Text, EpisodeDescription.Text));
                    EpisodeSeasonNumber.Text = "";
                    EpisodeNumber.Text = "";
                    EpisodeName.Text = "";
                    EpisodeDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Episode number and season number should be integer!");
                }
            }
            else
            {
                MessageBox.Show("Fields can't be null!");
            }
        }

        private void SeriesAdd_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SeriesName.Text != null & SeriesReleaseYear.Text != null & SeriesGenre.Text != null & SeriesCountries.Text != null & SeriesNumberOfSeasons != null & SeriesDirectors.Text != null & seriesActors.Count() > 0 & episodes.Count() > 0) 
            {
                if ((Int32.TryParse(SeriesReleaseYear.Text, out int releaseYear)) & (Int32.TryParse(SeriesNumberOfSeasons.Text, out int numberOfSeasons)))
                {
                    if (ApplicationOperator.AddSeries(SeriesName.Text, SeriesGenre.Text, seriesActors, SeriesDirectors.Text, SeriesCountries.Text, SeriesDescription.Text, episodes, SeriesEndYear.Text, releaseYear))
                    {
                        ClearSeries();
                    }
                    else
                    {
                        MessageBox.Show("This series already exits");
                    }
                }
                else
                {
                    MessageBox.Show("Release year and number of seasons should be integer!");
                }
            }
        }

        private void SeriesClearAll_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearSeries();
        }

        private void FilmAddActor_Button_Click(object sender, RoutedEventArgs e)
        {
            if (FilmActor.Text != null & FilmRole.Text != null)
            {
                filmActors.Add(ApplicationOperator.AddActors(FilmActor.Text, FilmRole.Text));
                FilmActor.Text = "";
                FilmRole.Text = "";
            }
            else
            {
                MessageBox.Show("Actor or role field can't be empty");
            }
        }

        private void FilmAdd_Button_Click(object sender, RoutedEventArgs e)
        {
            if (FilmName.Text != null & FilmReleaseYear.Text != null & FilmGenre.Text != null & FilmCountries.Text != null & FilmDirectors.Text != null & filmActors.Count() > 0)
            {
                if (Int32.TryParse(FilmReleaseYear.Text, out int releaseYear))
                {
                    if(ApplicationOperator.AddFilm(FilmName.Text, FilmGenre.Text, filmActors, FilmDirectors.Text, FilmCountries.Text, FilmDescription.Text, releaseYear))
                    {
                        ClearFilm();
                    }
                    else
                    {
                        MessageBox.Show("This film already exits");
                    }
                }
                else
                {
                    FilmReleaseYear.Text = "";
                    MessageBox.Show("Release year should be integer!");
                }
            }
            else
            {
                MessageBox.Show("Fields can't be null!");
            }
        }

        private void FilmClearAll_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearFilm();
        }
        private void ClearFilm()
        {
            FilmName.Text = "";
            FilmReleaseYear.Text = "";
            FilmGenre.Text = "";
            FilmCountries.Text = "";
            FilmDirectors.Text = "";
            FilmActor.Text = "";
            FilmRole.Text = "";
            FilmDescription.Text = "";
            filmActors = new List<string>();
        }
        private void ClearSeries()
        {
            SeriesName.Text = "";
            SeriesReleaseYear.Text = "";
            SeriesEndYear.Text = "";
            SeriesGenre.Text = "";
            SeriesCountries.Text = "";
            SeriesNumberOfSeasons.Text = "";
            SeriesDirectors.Text = "";
            SeriesActor.Text = "";
            SeriesRole.Text = "";
            SeriesDescription.Text = "";
            EpisodeSeasonNumber.Text = "";
            EpisodeNumber.Text = "";
            EpisodeName.Text = "";
            EpisodeDescription.Text = "";
            seriesActors = new List<string>();
            episodes = new List<Episode>();
        }
    }
}

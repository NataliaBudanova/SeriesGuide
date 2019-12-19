using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientApplication
{
    /// <summary>
    /// Логика взаимодействия для SeriesDetails.xaml
    /// </summary>
    public partial class SeriesDetails : Window
    {
        private Series currentSeries;
        private List<Episode> unwatchedEpisodes = new List<Episode>();
        public SeriesDetails(Series CurrentSeries)
        {
            InitializeComponent();
            WatchedEpisodes.ItemsSource = null;
            UnwatchedEpisodes.ItemsSource = null;
           ReviewsBox.ItemsSource = null;
            ActorsBox.ItemsSource = null;
            currentSeries = CurrentSeries;
            Name.Text = currentSeries.Name;
            TotalRate.Text = currentSeries.GetTotalRating().ToString();
            if (currentSeries.IsEnded)
            {
                Years.Text = $"{currentSeries.ReleaseYear}-{currentSeries.EndYear}";
            }
            else
            {
                Years.Text = $"{currentSeries.ReleaseYear}-now";
            }
            Countries.Text = currentSeries.Countries;
            Directors.Text = currentSeries.Directors;
            Seasons.Text = currentSeries.NumberOfSeasons.ToString();
            Description.Text = currentSeries.Description;
            ActorsBox.ItemsSource = currentSeries.Actors;
            ReviewsBox.ItemsSource = Factory.Instance.seriesRepository.Reviews[currentSeries.Id];
            WatchedEpisodes.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Added[currentSeries.Id];
            foreach (Episode episode in currentSeries.Episodes)
            {
                if (!Factory.Instance.accountRepository.CurrentAccount.Added[currentSeries.Id].Contains(episode))
                {
                    unwatchedEpisodes.Add(episode);
                }
            }
            UnwatchedEpisodes.ItemsSource = unwatchedEpisodes;

        }

        private void AddReview_Button_click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(CurrentRate.Text, out int currentRate))
            {
                if (currentRate <= 10)
                {
                    int currentId = Factory.Instance.accountRepository.CurrentAccount.Id;
                    string currentLogin = Factory.Instance.accountRepository.CurrentAccount.Login;
                    Review currentReview = new Review(currentRate, CurrentCommnet.Text, currentId, currentLogin);
                    if (currentSeries.AddReview(currentReview))
                    {
                        CurrentRate.Text = "";
                        CurrentCommnet.Text = "";
                        ReviewsBox.ItemsSource = null;
                        ReviewsBox.ItemsSource = Factory.Instance.seriesRepository.Reviews[currentSeries.Id];
                    }
                    else
                    {
                        MessageBox.Show("You've alredy writtren a review for this series!");
                    }
                }
                else
                {
                    CurrentRate.Text = "";
                    MessageBox.Show("Rate should be less than 10!");
                }
            }
            else
            {
                CurrentRate.Text = "";
                MessageBox.Show("Rate should be integer!");
            }
        }

        private void MoveEpisodeToWatched_Button_click(object sender, RoutedEventArgs e)
        {
            if (UnwatchedEpisodes.SelectedItem != null)
            {
                unwatchedEpisodes.Remove((Episode)UnwatchedEpisodes.SelectedItem);
                Factory.Instance.accountRepository.CurrentAccount.AddEpisode(currentSeries.Id, (Episode)UnwatchedEpisodes.SelectedItem);
                WatchedEpisodes.ItemsSource = null;
                UnwatchedEpisodes.ItemsSource = null;
                WatchedEpisodes.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Added[currentSeries.Id];
                UnwatchedEpisodes.ItemsSource = unwatchedEpisodes;
            }
        }

        private void MoveEpisodeToUnwatched_Button_click(object sender, RoutedEventArgs e)
        {
            if (WatchedEpisodes.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.RemoveEpisode(currentSeries.Id, (Episode)WatchedEpisodes.SelectedItem);
                WatchedEpisodes.ItemsSource = null;
                UnwatchedEpisodes.ItemsSource = null;
                unwatchedEpisodes.Add((Episode)WatchedEpisodes.SelectedItem);
                WatchedEpisodes.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Added[currentSeries.Id];
                UnwatchedEpisodes.ItemsSource = unwatchedEpisodes;
            }
        }
    }
}

using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.ClientApplicationComponents;
using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Account currentAccount;
        public MainWindow()
        {
            InitializeComponent();
            currentAccount = Factory.Instance.accountRepository.CurrentAccount;
            UpdateAll();
        }
        private void UpdateAll()
        {
            addedBox.ItemsSource = null;
            recentSeriesBox.ItemsSource = null;
            watchListBox.ItemsSource = null;
            recentFilmsBox.ItemsSource = null;
            watchedBox.ItemsSource = null;
            addedBox.ItemsSource = GetAddedSeries();
            recentSeriesBox.ItemsSource = Factory.Instance.seriesRepository.RecentSeries;
            watchListBox.ItemsSource = GetWatchList();
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.ReсentFilms;
            watchedBox.ItemsSource = GetWatched();
        }
        private List<Series> GetAddedSeries()
        {
            List<Series> addedSeries = new List<Series>();
            foreach (int seriesId in currentAccount.AddedSeries)
            {
                addedSeries.Add(Factory.Instance.seriesRepository.Items.First(s => s.Id == seriesId));
            }
            return addedSeries;
        }
        private List<Film> GetWatchList()
        {
            List<Film> watchList = new List<Film>();
            foreach (int filmId in currentAccount.WatchList)
            {
                watchList.Add(Factory.Instance.filmRepository.Items.First(f => f.Id == filmId));
            }
            return watchList;
        }
        private List<Film> GetWatched()
        {
            List<Film> watched = new List<Film>();
            foreach (int filmId in currentAccount.Watched)
            {
                watched.Add(Factory.Instance.filmRepository.Items.First(f => f.Id == filmId));
            }
            return watched;
        }

        private void AddedSearch_Button_click(object sender, RoutedEventArgs e)
        {
            addedBox.ItemsSource = null;
            addedBox.ItemsSource = GetAddedSeries().Where(s => s.Name.ToLower().Contains(AddedSearch.Text.ToLower()));
            AddedSearch.Text = "";
        }

        private void AddedDetails_Button_click(object sender, RoutedEventArgs e)
        {
            SeriesDetails seriesDetails = new SeriesDetails((Series)addedBox.SelectedItem);
            seriesDetails.Show();
        }

        private void AddedDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (addedBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.RemoveFromAddedSeries((Series)addedBox.SelectedItem);
                UpdateAll();
            }
        }

        private void NewSeriesSearch_Button_click(object sender, RoutedEventArgs e)
        {
            recentSeriesBox.ItemsSource = null;
            recentSeriesBox.ItemsSource = Factory.Instance.seriesRepository.Items.Where(s => s.Name.ToLower().Contains(AddedSearch.Text.ToLower()));
            NewSeriesSearch.Text = "";
        }

        private void NewSeriesDetails_Button_click(object sender, RoutedEventArgs e)
        {
            SeriesDetails seriesDetails = new SeriesDetails((Series)recentSeriesBox.SelectedItem);
            seriesDetails.Show();
        }

        private void NewSeriesAdd_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentSeriesBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.AddSeries((Series)recentSeriesBox.SelectedItem);
                UpdateAll();
            }
        }

        private void WatchListSearch_Button_click(object sender, RoutedEventArgs e)
        {
            watchListBox.ItemsSource = null;
            watchListBox.ItemsSource = GetWatchList().Where(f => f.Name.ToLower().Contains(WatchListSearch.Text.ToLower()));
            WatchListSearch.Text = "";
        }

        private void WatchListDetails_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchListBox.SelectedItem != null)
            {
                FilmDetails filmDetails = new FilmDetails((Film)watchListBox.SelectedItem);
                filmDetails.Show();
            }
        }

        private void WatchListDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchListBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.RemoveFromWatchList((Film)watchListBox.SelectedItem);
                UpdateAll();
            }
        }

        private void NewFilmsSearch_Button_click(object sender, RoutedEventArgs e)
        {
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.Items.Where(f => f.Name.ToLower().Contains(NewFilmSearch.Text.ToLower()));
            NewFilmSearch.Text = "";
        }

        private void NewFilmsDetails_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                FilmDetails filmDetails = new FilmDetails((Film)recentFilmsBox.SelectedItem);
                filmDetails.Show();
            }
        }

        private void NewFilmsAddToWatchList_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.AddToWatchList((Film)recentFilmsBox.SelectedItem);
                UpdateAll();
            }
        }

        private void NewFilmsAddToWatched_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.AddToWatched((Film)recentFilmsBox.SelectedItem);
                UpdateAll();
            }

        }

        private void WatchedSearch_Button_click(object sender, RoutedEventArgs e)
        {
            recentFilmsBox.ItemsSource = null;
            recentFilmsBox.ItemsSource = GetWatched().Where(f => f.Name.ToLower().Contains(WatchedSearch.Text.ToLower()));
            NewFilmSearch.Text = "";
        }

        private void WatchedDetails_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchedBox.SelectedItem != null)
            {
                FilmDetails filmDetails = new FilmDetails((Film)watchedBox.SelectedItem);
                filmDetails.Show();
            }
        }

        private void WatchedDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchedBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.RemoveFromWatched((Film)watchedBox.SelectedItem);
                UpdateAll();
            }
        }

        private void NewFilmsBack_Button_click(object sender, RoutedEventArgs e)
        {
            UpdateAll();
            NewFilmSearch.Text = "";
        }

        private void NewSeriesBack_Button_click(object sender, RoutedEventArgs e)
        {
            UpdateAll();
            NewSeriesSearch.Text = "";
        }

        private void ChangeLogin_Click(object sender, RoutedEventArgs e)
        {
            string message;
            if(SettingsManager.ChangeLogin(ChangeLoginTextBox.Text, out message))
            {
                MessageBox.Show(message);
            }
        }
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string message;
            if (SettingsManager.ChangePassword(ChangeLoginTextBox.Text, out message))
            {
                MessageBox.Show(message);
            }
        }


        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            SettingsManager.LogOut();
            new LoginWindow().Show();
            this.Close();
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            SettingsManager.DeleteAccount();
            new LoginWindow().Show();
            this.Close();
        }

        
    }
}

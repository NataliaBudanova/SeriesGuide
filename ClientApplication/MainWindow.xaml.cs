using SeriesGuide.Core.ApplicationComponents;
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
        public MainWindow()
        {
            InitializeComponent();
            UpdateAll();
        }
        private void UpdateAll()
        {
            addedBox.ItemsSource = null;
            recentFilmsBox.ItemsSource = null;
            watchListBox.ItemsSource = null;
            recentFilmsBox.ItemsSource = null;
            watchedBox.ItemsSource = null;
            addedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.AddedSeries;
            recentSeriesBox.ItemsSource = Factory.Instance.seriesRepository.RecentSeries;
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList;
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.ReсentFilms;
            watchedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched;
        }

        private void AddedSearch_Button_click(object sender, RoutedEventArgs e)
        {
            addedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.AddedSeries.Where(s => s.Name.ToLower().Contains(AddedSearch.Text.ToLower()));
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
                addedBox.ItemsSource = null;
                addedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.AddedSeries;
            }
        }

        private void NewSeriesSearch_Button_click(object sender, RoutedEventArgs e)
        {
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
                addedBox.ItemsSource = null;
                addedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.AddedSeries;
            }
        }

        private void WatchListSearch_Button_click(object sender, RoutedEventArgs e)
        {
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList.Where(f => f.Name.ToLower().Contains(WatchListSearch.Text.ToLower()));
            WatchListSearch.Text = "";
        }

        private void WatchListDetails_Button_click(object sender, RoutedEventArgs e)
        {
            FilmDetails filmDetails = new FilmDetails((Film)watchListBox.SelectedItem);
            filmDetails.Show();
        }

        private void WatchListDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchListBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.RemoveFromWatchList((Film)watchListBox.SelectedItem);
                watchListBox.ItemsSource = null;
                watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList;
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
                watchListBox.ItemsSource = null;
                watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList;
            }
        }

        private void NewFilmsAddToWatched_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.AddToWatched((Film)recentFilmsBox.SelectedItem);
                watchedBox.ItemsSource = null;
                watchedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched;
            }

        }

        private void WatchedSearch_Button_click(object sender, RoutedEventArgs e)
        {
            recentFilmsBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched.Where(f => f.Name.ToLower().Contains(WatchedSearch.Text.ToLower()));
            NewFilmSearch.Text = "";
        }

        private void WatchedDetails_Button_click(object sender, RoutedEventArgs e)
        {
            FilmDetails filmDetails = new FilmDetails((Film)watchedBox.SelectedItem);
            filmDetails.Show();
        }

        private void WatchedDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchedBox.SelectedItem != null)
            {
                Factory.Instance.accountRepository.CurrentAccount.RemoveFromWatched((Film)watchedBox.SelectedItem);
                watchedBox.ItemsSource = null;
                watchedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched;
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

        }
    }
}

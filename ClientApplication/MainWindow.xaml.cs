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
            addedBox.ItemsSource = Factory.Instance.seriesRepository.Items;
            recentSeriesBox.ItemsSource = Factory.Instance.seriesRepository.RecentSeries;
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList;
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.ReсentFilms;
            watchedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched;
        }

        private void AddedSearch_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void AddedDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void AddedDelete_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewSeriesSearch_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewSeriesDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewSeriesAdd_Button_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void WatchListSearch_Button_click(object sender, RoutedEventArgs e)
        {
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList.Where(f => f.Name.Equals(WatchListSearch.Text));
            WatchListSearch.Text = "";
        }

        private void WatchListDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchListDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchListBox.SelectedItem != null)
            {
                /*Film selectedFilm = Factory.Instance.filmRepository.Items.First(f => f == (Film)watchListBox.SelectedItem);*/
                Factory.Instance.accountRepository.CurrentAccount.RemoveFromToWatchList((Film)watchListBox.SelectedItem);
                watchListBox.ItemsSource = null;
                watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList;
            }
        }

        private void NewFilmsSearch_Button_click(object sender, RoutedEventArgs e)
        {
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.Items.Where(f => f.Name.Equals(NewFilmSearch.Text));
            NewFilmSearch.Text = "";
        }

        private void NewFilmsDetails_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                Film selectedFilm = Factory.Instance.filmRepository.Items.First(f => f == recentFilmsBox.SelectedItem);
                FilmDetails filmDetails = new FilmDetails(selectedFilm);
                filmDetails.Show();
            }
        }

        private void NewFilmsAddToWatchList_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                Film selectedFilm = Factory.Instance.filmRepository.Items.First(f => f == recentFilmsBox.SelectedItem);
                Factory.Instance.accountRepository.CurrentAccount.AddToWatchList(selectedFilm);
                watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList;
            }
        }

        private void NewFilmsAddToWatched_Button_click(object sender, RoutedEventArgs e)
        {
            if (recentFilmsBox.SelectedItem != null)
            {
                Film selectedFilm = Factory.Instance.filmRepository.Items.First(f => f == recentFilmsBox.SelectedItem);
                Factory.Instance.accountRepository.CurrentAccount.AddToWatched(selectedFilm);
                watchedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched;
            }

        }

        private void WatchedSearch_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchedDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchedDelete_Button_click(object sender, RoutedEventArgs e)
        {
            if (watchedBox.SelectedItem != null)
            {
                /*Film selectedFilm = Factory.Instance.filmRepository.Items.First(f => f == watchedBox.SelectedItem);*/
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

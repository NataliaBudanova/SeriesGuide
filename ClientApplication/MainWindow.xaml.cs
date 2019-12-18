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
            addedBox.ItemsSource = Factory.Instance.seriesRepository.Items.Select(s => s.Name);
            recentSeriesBox.ItemsSource = Factory.Instance.seriesRepository.RecentSeries.Select(s => s.Name);
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList.Select(f => f.Name);
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.ReсentFilms.Select(f => f.Name);
            watchedBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.Watched.Select(f => f.Name);
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
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList.Where(f => f.Name.Equals(WatchListSearch));
        }

        private void WatchListDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchListDelete_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewFilmsSearch_Button_click(object sender, RoutedEventArgs e)
        {
            recentFilmsBox.ItemsSource = Factory.Instance.filmRepository.Items.Where(f => f.Name.Equals(NewFilmSearch.Text)).Select(f => f.Name);
        }

        private void NewFilmsDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewFilmsAddToWatchList_Button_click(object sender, RoutedEventArgs e)
        {
            Film selectedFilm = Factory.Instance.filmRepository.Items.First(f => f.Name.Equals(recentFilmsBox.SelectedItem.ToString()));
            Factory.Instance.accountRepository.CurrentAccount.AddToWatchList(selectedFilm);
            watchListBox.ItemsSource = Factory.Instance.accountRepository.CurrentAccount.WatchList.Select(f => f.Name);
        }

        private void NewFilmsAddToWatched_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchedSearch_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchedDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchedDelete_Button_click(object sender, RoutedEventArgs e)
        {

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

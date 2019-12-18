using SeriesGuide.Core.ApplicationComponents;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            recentSeriesBox.ItemsSource = Factory.Instance.seriesRepository.ResentSeries;
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

        }

        private void WatchListDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void WatchListDelete_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewFilmsSearch_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewFilmsDetails_Button_click(object sender, RoutedEventArgs e)
        {

        }

        private void NewFilmsAddToWatchList_Button_click(object sender, RoutedEventArgs e)
        {

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
    }
}

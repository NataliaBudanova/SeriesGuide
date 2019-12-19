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
        public SeriesDetails(Series currentSeries)
        {
            InitializeComponent();
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

        }

        private void AddReview_Button_click(object sender, RoutedEventArgs e)
        {

        }
    }
}

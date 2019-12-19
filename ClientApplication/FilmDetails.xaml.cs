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
    /// Логика взаимодействия для FilmDetails.xaml
    /// </summary>
    public partial class FilmDetails : Window
    {
        public FilmDetails(Film currentFilm)
        {
            InitializeComponent();
            Name.Text = currentFilm.Name;
            TotalRate.Text = $"{currentFilm.GetTotalRating().ToString()}/10";
            Year.Text = currentFilm.ReleaseYear.ToString();
            Countries.Text = currentFilm.Countries;
            Directors.Text = currentFilm.Directors;
            ActorsBox.ItemsSource = currentFilm.Actors;
            Description.Text = currentFilm.Description;

        }

        private void AddReview_Button_click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

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
    /// Логика взаимодействия для FilmDetails.xaml
    /// </summary>
    public partial class FilmDetails : Window
    {
        private Film currentFilm;
        public FilmDetails(Film CurrentFilm)
        {
            currentFilm = CurrentFilm;
            InitializeComponent();
            Name.Text = currentFilm.Name;
            TotalRate.Text = $"{currentFilm.GetTotalRating().ToString()}/10";
            Year.Text = currentFilm.ReleaseYear.ToString();
            Countries.Text = currentFilm.Countries;
            Directors.Text = currentFilm.Directors;
            ActorsBox.ItemsSource = currentFilm.Actors;
            Description.Text = currentFilm.Description;
            ReviewsBox.ItemsSource = null;
            ReviewsBox.ItemsSource = Factory.Instance.filmRepository.Reviews[currentFilm.Id];

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
                    if (currentFilm.AddReview(currentReview))
                    {
                        CurrentRate.Text = "";
                        CurrentCommnet.Text = "";
                        ReviewsBox.ItemsSource = null;
                        ReviewsBox.ItemsSource = Factory.Instance.filmRepository.Reviews[currentFilm.Id];
                    }
                    else
                    {
                        MessageBox.Show("You've alredy writtren a review for this film!");
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
    }
}

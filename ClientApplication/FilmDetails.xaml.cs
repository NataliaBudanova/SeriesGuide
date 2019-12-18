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
        public FilmDetails(Film CurrentFilm)
        {
            InitializeComponent();
            FilmName.Text = CurrentFilm.Name;
        }
    }
}

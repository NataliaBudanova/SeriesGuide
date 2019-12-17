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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void WithoutAccount_button_click(object sender, RoutedEventArgs e)
        {

        }

        private void Registration_button_click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void Login_button_click(object sender, RoutedEventArgs e)
        {
            
            //string login = Login.Text;
            //string password = Password.Password;
            //if (Container.Default(true).Repositories[typeof(IRepository<Account>)].Any(x => x.Login == login & x.Password == password))
            //{

            //}
            //else
            //{
            //    MessageBox.Show("This account doesn't exists.", "Error!");
            //    Login.Text = "";
            //    Password.Password = "";
            //}
        }
    }
}

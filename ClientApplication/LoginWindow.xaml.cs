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
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IEnumerable<Account> data;

        public LoginWindow()
        {
            InitializeComponent();
            GetData();
            if (Factory.Instance.accountRepository.CurrentAccount != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void GetData()
        {
            data = Factory.Instance.accountRepository.Items;
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

            string login = Login.Text;
            string password = Password.Password;
            if(data.Any(x => x.Login == login & x.Password == password))
            {
                Factory.Instance.accountRepository.CurrentAccount = data.First(x => x.Login == login);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("This account doesn't exists.", "Error!");
                Password.Password = "";
            }
        }
    }
}

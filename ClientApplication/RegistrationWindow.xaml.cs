using System.Windows;
using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.ClientApplicationComponents;

namespace ClientApplication
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Back_button_click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Registration_button_click(object sender, RoutedEventArgs e)
        {
            string message;
            if (RegisterManager.IsValid(Name.Text,PhoneNumber.Text,Password1.Password,Password2.Password, out message))
                RegisterManager.RegistrateAccount(Name.Text, PhoneNumber.Text, Password1.Password);
            else
            {
                MessageBox.Show(message);
            }

        }
    }
}

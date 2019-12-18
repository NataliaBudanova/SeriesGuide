using SeriesGuide.Core.ApplicationComponents;
using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SeriesGuide.Core.ClientApplicationComponents
{
    public class RegisterManager
    {
        public static bool IsValid(string login, string phoneNumber, string password1, string password2, out string message)
        {
            if (login.Length == 0 || phoneNumber.Length == 0 || password1.Length == 0 || password2.Length == 0)
            {
                message = "Fields should not be empty!";
                return false;
            }
            else if(Factory.Instance.accountRepository.Items.Any(a => a.PhoneNumber == phoneNumber))
            {
                message = "Account with the same number has been already registered!";
                return false;
            }
            else if(Factory.Instance.accountRepository.Items.Any(a => a.Login == login))
            {
                message = "Account with the same login already exists!";
                return false;
            }
            else if(password1 != password2)
            {
                message = "Passwords must be equal!";
                return false;
            }
            else
            {
                message = "";
                return true;
            }
                
        }

        public static void RegistrateAccount(string login, string phoneNumber, string password)
        {
            Factory.Instance.accountRepository.Add(new Account( 
                id: (Factory.Instance.accountRepository.Items.Count() == 0) ? 1 : Factory.Instance.accountRepository.Items.Max(a => a.Id) + 1,
                login: login,
                phoneNumber: phoneNumber,
                password: password));
        }
    }
}

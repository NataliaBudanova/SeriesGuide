using SeriesGuide.Core.ApplicationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ClientApplicationComponents
{
    public class SettingsManager
    {
        public static bool ChangeLogin(string login, out string message)
        {
            if (!IfLoginExists(login))
            {
                if (login == "")
                {
                    message = "Login field must be filled!";
                    return true;
                }
                Factory.Instance.accountRepository.CurrentAccount.Login = login;
                Factory.Instance.accountRepository.UpdateAccount(Factory.Instance.accountRepository.CurrentAccount.Id);
                message = null;
                return false;
            }
            else if (login == Factory.Instance.accountRepository.CurrentAccount.Login)
                    {
                        message = "New login must not be equal to the previous one!";
                        return true;
                    }
                    else
                        {
                            message = "Account with the same login already exists!";
                            return true;
                        }    
        }

        private static bool IfLoginExists(string login)
        {
            return Factory.Instance.accountRepository.Items.Any(a => a.Login == login);
        }

        public static bool ChangePassword(string password, out string message)
        {
            if (IsPasswordValid(password))
            {
                if (password == "")
                {
                    message = "Password field must be filled!";
                    return true;
                }
                Factory.Instance.accountRepository.CurrentAccount.Password = password;
                Factory.Instance.accountRepository.UpdateAccount(Factory.Instance.accountRepository.CurrentAccount.Id);
                message = null;
                return false;
            }
            else
            {
                message = "New password must not be equal to the previous one!";
                return true;
            }
        }

        private static bool IsPasswordValid(string password)
        {
            return password != Factory.Instance.accountRepository.CurrentAccount.Password;
        }

        public static void LogOut()
        {
            Factory.Instance.accountRepository.DeleteAccount(Factory.)
        }
    }
}

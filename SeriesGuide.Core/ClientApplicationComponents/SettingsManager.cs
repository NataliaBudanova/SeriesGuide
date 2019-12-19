using SeriesGuide.Core.ApplicationComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ClientApplicationComponents
{
    public class SettingsManager
    {
        public static bool ChangeLogin(string login)
        {
            if (!IfExists(login))
            {
                Factory.Instance.accountRepository.CurrentAccount.Login = login;
                Factory.Instance.accountRepository.UpdateAccount(Factory.Instance.accountRepository.CurrentAccount.Id);
                return true;
            }
            else
                return false;
            
        }

        private static bool IfExists(string login)
        {
            return Factory.Instance.accountRepository.Items.Any(a => a.Login == login);
        }


    }
}

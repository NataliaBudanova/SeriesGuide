using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class AccountRepository : IRepository<Account>
    {
        private Account currentAccount;
        private List<Account> items;

        public Account CurrentAccount
        {
            get
            {
                return currentAccount;
            }
            set
            {
                currentAccount = value;
                JsonConvertor.Save<AccountsData>(new AccountsData() {
                    Current = currentAccount, Accounts = items 
                }, Path.Combine(FolderPath, FileName));
            }
        }
        public IEnumerable<Account> Items => items;

        public AccountRepository()
        {
            AccountsData data = JsonConvertor.UpLoad<AccountsData>(Path.Combine(FolderPath, FileName));
            items = data.Accounts;
            currentAccount = data.Current;
        }

        public void Add(Account item)
        {
            items.Add(item);
            JsonConvertor.Save<AccountsData>(new AccountsData()
            {
                Current = currentAccount,
                Accounts = items
            }, Path.Combine(FolderPath, FileName));
        }

        public void Remove(int Id)
        {
            items.Remove(items.First(a => a.Id == Id));
            JsonConvertor.Save<AccountsData>(new AccountsData()
            {
                Current = null,
                Accounts = items
            }, Path.Combine(FolderPath, FileName));
        }

        public void UpdateAccount(int Id)
        {
            items.Remove(items.First(a => a.Id == Id));
            items.Add(currentAccount);
            JsonConvertor.Save<AccountsData>(new AccountsData()
            {
                Current = currentAccount,
                Accounts = items
            }, Path.Combine(FolderPath, FileName));
        }

        private const string FileName = "AccountsData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

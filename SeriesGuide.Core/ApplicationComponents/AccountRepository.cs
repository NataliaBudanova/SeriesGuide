using SeriesGuide.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeriesGuide.Core.ApplicationComponents
{
    public class AccountRepository : IRepository<Account>
    {
        private Account currentAccount;
        private List<Account> items;
        private IJsonConvertor convertor = new JsonConvertor();

        public Account CurrentAccount
        {
            get
            {
                return currentAccount;
            }
            set
            {
                currentAccount = value;
                convertor.Save<AccountsData>(new AccountsData() {
                    current = currentAccount, accounts = items 
                }, Path.Combine(FolderPath, FileName));
            }
        }
        public IEnumerable<Account> Items => items;

        public AccountRepository(IJsonConvertor convertor)
        {
            AccountsData data = convertor.UpLoad<AccountsData>(Path.Combine(FolderPath, FileName));
            currentAccount = data.current;
            items = data.accounts;
        }

        public void Add(Account item)
        {
            items.Add(item);
            convertor.Save<AccountsData>(new AccountsData()
            {
                current = currentAccount,
                accounts = items
            }, Path.Combine(FolderPath, FileName));
        }

        private const string FileName = "AccountsData.json";
        private const string FolderPath = "../../../../SeriesGuide.Core/Data";
    }
}

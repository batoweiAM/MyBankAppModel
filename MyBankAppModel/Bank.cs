using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Bank
    {
        private List<Account> accounts;

        public Bank() 
        {
            accounts = new List<Account>();
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string AccountType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Account()
        {
            this.Transactions = new List<Transaction>();
        }

        public void AddBalance(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Invalid amount. Amount must be greater than zero.");
            }

            Balance += amount;
        }

        public void DeductBalance(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Invalid amount. Amount must be greater than zero.");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds in the account.");
            }

            Balance -= amount;
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }
    
}
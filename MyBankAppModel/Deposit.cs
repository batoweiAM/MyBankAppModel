using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Deposit
    {
        public void MakeDeposit(Account account)
        {
            Console.WriteLine("Enter Amount to deposit");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount <= 0)
            {
                throw new ArgumentException("Invalid deposit amount. Amount must be greater than zero.");
            }

            account.AddBalance(amount);
            Console.WriteLine($"Successfully deposited {amount:C}. New balance: {account.GetBalance():C}");

            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Deposit",
                Amount = amount,
                Balance = account.GetBalance()
            });
        }
    }
}

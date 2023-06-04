using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Withdraw
    {
        public void MakeWithdrawal(Account account)
        {
            Console.WriteLine("Enter the amount to withdraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (account.AccountType == "Savings")
            {
                if (amount > account.Balance || amount > 1000)
                {
                    Console.WriteLine("Invalid withdrawal amount. You can only withdraw up to 1000 or your current balance.");
                }
                else
                {
                    account.DeductBalance(amount);
                    Console.WriteLine($"Successfully withdrew {amount} from the savings account.");
                }
            }
            else if (account.AccountType == "Current")
            {
                if (amount > account.Balance)
                {
                    Console.WriteLine("Invalid withdrawal amount. You can only withdraw up to your current balance.");
                }
                else
                {
                    account.DeductBalance(amount);
                    Console.WriteLine($"Successfully withdrew {amount} from the current account.");
                    account.Transactions.Add(new Transaction
                    {
                        Date = DateTime.Now,
                        Description = "Withdrawal",
                        Amount = amount,
                        Balance = account.GetBalance()
                    });
                }
            }
            else
            {
                Console.WriteLine("Invalid account type.");
            }
        }
    }
}

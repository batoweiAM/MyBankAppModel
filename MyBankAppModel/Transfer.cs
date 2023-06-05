using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Transfer
    {
        public void MakeTransfer(Bank bank, Account sourceAccount)
        {
            Console.WriteLine("Enter the destination Account");
            string destinationAccountNumber = Console.ReadLine();

            Account destinationAccount = bank.GetAccounts().FirstOrDefault(x => x.AccountNumber == destinationAccountNumber);

            Console.WriteLine("Enter amount to transfer");
            decimal amount;
            if (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid transfer amount. Amount must be a positive number.");
                return;
            }

            if (destinationAccount == null)
            {
                Console.WriteLine("Invalid destination account not found.");
                return;
            }

            if (amount > sourceAccount.GetBalance())
            {
                Console.WriteLine("Insufficient funds in the source account.");
                return;
            }

            sourceAccount.DeductBalance(amount);
            destinationAccount.AddBalance(amount);

            Console.WriteLine($"Successfully transferred {amount:C} from {sourceAccount.AccountNumber} to {destinationAccount.AccountNumber}.");
            Console.WriteLine($"Source account balance: {sourceAccount.GetBalance():C}");
            Console.WriteLine($"Destination account balance: {destinationAccount.GetBalance():C}");

            sourceAccount.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = $"Transfer to {destinationAccount.AccountNumber}",
                Amount = amount,
                Balance = sourceAccount.GetBalance()
            });

            destinationAccount.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = $"Transfer from {sourceAccount.AccountNumber}",
                Amount = amount,
                Balance = destinationAccount.GetBalance()
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyBankAppModel
{
    public class OpenAccount
    {
        public static bool ValidateInput(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        public void RegisterCustomer(Bank bank)
        {
            Console.Write("Enter firstname: ");
            string firstName = Console.ReadLine();
            while (!ValidateInput(firstName, @"^[a-zA-Z]+$"))
            {
                Console.Write("Invalid input. Please enter a valid firstname: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Enter lastname: ");
            string lastName = Console.ReadLine();
            while (!ValidateInput(lastName, @"^[a-zA-Z]+$"))
            {
                Console.Write("Invalid input. Please enter a valid lastname: ");
                lastName = Console.ReadLine();
            }

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            while (!ValidateInput(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                Console.Write("Invalid input. Please enter a valid email: ");
                email = Console.ReadLine();
            }

            Console.Write("Enter preferred password: ");
            string password = Console.ReadLine();
            List<object> accountInfo = GenerateAccount();
            Console.WriteLine("Make initial deposit");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Account account = new Account()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                AccountType = (string)(accountInfo[1]),
                AccountNumber = (string)(accountInfo[0]),
                Balance = amount

            };
            bank.AddAccount(account);
            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Initial deposit",
                Amount = amount,
                Balance = account.GetBalance()
            });

            Console.WriteLine("Press Enter to Continue");

        }
        public List<object> GenerateAccount()
        {
            Console.WriteLine("Enter 1 for Savings Account or 2 for Current Account");
            string accountType = Console.ReadLine();
            string accountNumber = "";
            Random random = new Random();
            if (accountType == "1")
            {
                
                accountNumber = "0" + random.Next().ToString().Substring(0, 9);
                accountType = "Savings";

            }
            else if (accountType == "2")
            {
                accountNumber = "1" + random.Next().ToString().Substring(0, 9);
                accountType = "Current";
            }
            Console.WriteLine($"Your account NO is {accountNumber}");
            return new List<object>() { accountNumber, accountType };
        }
    }
}

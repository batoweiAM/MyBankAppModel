using MyBankAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Login
    {
        public void LoginUser(Bank bank)
        {
            Console.WriteLine("Glad to have you here, please login with the correct details.");
            Console.Write("Enter Email: ");
            string enteredEmail = Console.ReadLine();

            Console.Write("Enter Password: ");
            string enteredPassword = Console.ReadLine();

            Account account  = bank.GetAccounts().Find(x=>x.Email == enteredEmail && x.Password ==enteredPassword);

            if (account != null)
            {
                Console.WriteLine("Login Successful!");
                BankOperations(account, bank);
            }
            else
            {
                Console.WriteLine("Invalid email or password. Login failed.");
            }
        }

        public void BankOperations(Account account, Bank bank)
        {
            string choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Bank Operations");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Get Balance");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5. Get Account Statement");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Follow the prompt to deposit");
                        Deposit credit = new Deposit();
                        credit.MakeDeposit(account);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Input withdraw amount");
                        Withdraw withdraw = new Withdraw();
                        withdraw.MakeWithdrawal(account);
                        break;
                    case "3":
                        Console.Clear();
                        Balance check = new Balance();
                        check.DisplayBalance(account);
                        break;
                    case "4":
                        Console.Clear();
                        Transfer debit = new Transfer();
                        debit.MakeTransfer(bank, account);
                        break;
                    case "5":
                        Console.Clear();
                        Statement print = new Statement();
                        print.DisplayStatement(account);
                        break;
                    case "6":
                        Console.Clear();
                        Logout exit = new Logout();
                        exit.LogoutUser();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                } 
            } while (choice != "6");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class UserInterface
    {
        public void PromptUser()
        {
            Bank bank = new Bank();
            string choice;
            do
            {
                Console.WriteLine("WELCOME TO YOUR BANK APP");
                Console.WriteLine();
                Console.WriteLine("1. Register & OpenAccount");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your Choice");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("To Register and Open Account Please follow the prompt");
                        OpenAccount open = new OpenAccount();
                        open.RegisterCustomer(bank);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Thank you for Registering please Login");
                        Login login = new Login();
                        login.LoginUser(bank);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            } while (choice != "3"); 
        }
    }
}
using MyBankAppModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Balance
    {
        public void DisplayBalance(Account account)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("ACCOUNT DETAILS");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine($"| {account.FullName,-17} | {account.AccountNumber,-30} | {account.AccountType,-24} | {account.GetBalance(),-19:C} |");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.ResetColor();
        }
    }
}

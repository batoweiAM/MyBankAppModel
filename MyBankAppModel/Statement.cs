using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankAppModel
{
    public class Statement
    {
        public void DisplayStatement(Account account)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {account.AccountNumber}");
            Console.WriteLine("|-------------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| DATE                    | DESCRIPTION                   | AMOUNT                   | BALANCE             |");
            Console.WriteLine("|-------------------------|-------------------------------|--------------------------|---------------------|");


            foreach (Transaction transaction in account.Transactions)
            {
                Console.WriteLine($"| {transaction.Date,-17}    | {transaction.Description,-30}| {transaction.Amount,-24:C} | {transaction.Balance,-19:C} |");
            }

            Console.WriteLine("|-------------------------|-------------------------------|--------------------------|---------------------|");
            Console.ResetColor();
        }
    }
}

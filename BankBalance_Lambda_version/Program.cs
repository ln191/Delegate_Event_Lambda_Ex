using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBalance_Lambda_version
{
    public delegate void BalanceEventHandler(decimal amount);

    internal class Program
    {
        private static void Main(string[] args)
        {
            Account acc = new Account();

            //Used Statement Lambda instead of making the balanceLogger and balanceWatcher class
            //since they were so simple they could easily be on one line thereby make the code more readable
            //and saved us from instantiate two class
            acc.balanceChanged += (amount) => { Console.WriteLine($"The balance amount is {amount}"); };
            acc.balanceChanged += (amount) => { if (amount > 500.0m) Console.WriteLine($"You have reached your savings goal! You have {amount}"); };

            string theInput;
            do
            {
                Console.WriteLine("How much to deposit?");

                theInput = Console.ReadLine();
                if (!theInput.Equals("exit"))
                {
                    decimal amount = decimal.Parse(theInput);

                    acc.Balance += amount;
                }
            } while (!theInput.Equals("exit"));
        }
    }

    internal class Account
    {
        private decimal balance;

        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
                //when ever balance is changed it triggers the event
                balanceChanged(value);
            }
        }

        public event BalanceEventHandler balanceChanged;
    }
}
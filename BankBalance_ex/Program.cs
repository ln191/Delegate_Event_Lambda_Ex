using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBalance_ex
{
    public delegate void BalanceEventHandler(decimal amount);

    internal class Program
    {
        private static void Main(string[] args)
        {
            Account acc = new Account();
            BalanceLogger log = new BalanceLogger();
            BalanceWatcher watch = new BalanceWatcher();

            //adds the other delegate method to balanceChanged event
            acc.balanceChanged += log.balanceLog;
            acc.balanceChanged += watch.balanceWatch;

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

    internal class BalanceLogger
    {
        public void balanceLog(decimal amount)
        {
            Console.WriteLine($"The balance amount is {amount}");
        }
    }

    internal class BalanceWatcher
    {
        public void balanceWatch(decimal amount)
        {
            if (amount > 500.0m)
            {
                Console.WriteLine($"You have reached your savings goal! You have {amount}");
            }
        }
    }
}
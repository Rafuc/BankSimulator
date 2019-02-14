using BankSimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulator.Infrastructure
{
    internal class HomePage : Paymants
    {
        public bool isLogged = false;

        private int _actionChoose;
        private readonly StoreContext _storeContext;

        public HomePage(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public void StartPage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("What you want to do?");
            Console.WriteLine("1.Do a transfer");
            Console.WriteLine("2.See my transactions");
            Console.WriteLine("3.User Information");
            Console.WriteLine("4.Deposit money");
            Console.WriteLine("5.Withdraw money");
            Console.Write("Your choose: ");
            _actionChoose = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
        }

        public int ReturnChoose()
        {
            return _actionChoose;
        }
    }
}

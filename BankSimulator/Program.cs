using BankSimulator.Infrastructure;
using BankSimulator.Model;
using System;

namespace BankSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreContext storeContext = new StoreContext();

            LoginSystem _loginSystem = new LoginSystem(storeContext);
            _loginSystem.HelloMesseges();

            Console.ReadKey();
        }
    }
}

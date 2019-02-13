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
            HomePage _mainFuctions = new HomePage(storeContext);
            _mainFuctions.SetStoreContext(storeContext);

            while(!_loginSystem.userIsLogged)
            {
                _loginSystem.HelloMesseges();
            }

            while(!_mainFuctions.isLogged)
            {
                _mainFuctions.StartPage();

                if(_mainFuctions.ReturnChoose() == 1)
                {
                    _mainFuctions.Transfer();
                }
            }

            Console.ReadKey();
        }
    }
}

using BankSimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulator.Infrastructure
{
    class LoginSystem
    {
        private StoreContext _storeContext;

        public LoginSystem(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        private string FName;
        private string SName;
        private string LiveAddress;
        private int PhoneNumber;
        private string password;
        private int id;

        public void HelloMesseges()
        {
            Console.WriteLine("Hello in BankSimulator!");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. How to setup Bank Simulator");
            int choose = Convert.ToInt32(Console.ReadLine());

            if (choose == 1)
            {
                LogIn();
            }
            else if (choose == 2)
            {
                Register();
            }
            else if (choose == 3)
            {
                HowToSetup();
            }
            else
            {

            }
        }

        private void HowToSetup()
        {
            throw new NotImplementedException();
        }

        private void LogIn()
        {
            Console.Write("Login:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Password:");
            password = Console.ReadLine();

            foreach(var accounts in _storeContext.Account)
            {
                if(id == accounts.IdUser && password == accounts.Password)
                {
                    Console.WriteLine("Istnieje taki rekord w bazie danych!!");
                    break;
                }
                else
                {
                    Console.WriteLine("This is a bait :)");
                }
            }
        }

        private void Register()
        {
            Console.Write("First Name:");
            FName = Console.ReadLine();
            Console.Write("Second Name:");
            SName = Console.ReadLine();
            Console.Write("Live Address:");
            LiveAddress = Console.ReadLine();
            Console.Write("Phone Number:");
            PhoneNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Password to account:");
            password = Console.ReadLine();

            var account = new Account { FirstName = FName, SecondName = SName, LiveAddres = LiveAddress, PhoneNumber = PhoneNumber, Password = password };
            _storeContext.Add(account);
            _storeContext.SaveChanges();
        }
    }
}

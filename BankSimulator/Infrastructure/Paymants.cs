﻿using BankSimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulator.Infrastructure
{
    class Paymants : IPaymants
    {
        private StoreContext _storeContext;
        private int whoShouldReciveMoney;
        private decimal moneyToSend;
        private bool youCanSend = false;
        private decimal moneyToDeposit;
        private decimal moneyToWithdraw;

        public void CurrentlyCash()
        {
            foreach(var account in _storeContext.Account)
            {
                if(UserInformation.rememberMyId == account.IdUser)
                {
                    Console.WriteLine($"Your cash: {account.Cash} PLN");
                    Console.ReadKey();
                }
            }
        }

        public void DepositMoney()
        {
            Console.Write("How much money you want to deposit: ");
            moneyToDeposit = Convert.ToDecimal(Console.ReadLine());
            if (moneyToDeposit > 0)
            {
                foreach (var account in _storeContext.Account)
                {
                    if (UserInformation.rememberMyId == account.IdUser)
                    {
                        account.Cash += moneyToDeposit;
                    }
                }
                Console.WriteLine("Deposit succesfully");
                _storeContext.SaveChanges();
            }
            else
            {
                Console.WriteLine($"You cant deposit {moneyToDeposit}"); 
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void MyTransactions()
        {
            throw new NotImplementedException();
        }

        public void Transfer()
        {
            Console.Write("Say id who should recive your money: ");
            whoShouldReciveMoney = Convert.ToInt32(Console.ReadLine());
            Console.Write("How much money ?: ");
            moneyToSend = decimal.Parse(Console.ReadLine());

            if (whoShouldReciveMoney == UserInformation.rememberMyId)
            {
                Console.WriteLine("You can not send money yourself!");
            }

            foreach (var accounts in _storeContext.Account)
            {
                if (accounts.IdUser == UserInformation.rememberMyId)
                {
                    if (accounts.Cash <= 0)
                    {
                        youCanSend = false;

                        Console.WriteLine("You cant send money");
                    }
                    else
                    {
                        if (moneyToSend >= accounts.Cash && moneyToSend <= 0)
                        {
                            Console.WriteLine("You do not have enough money to make a transfer");
                        }
                        else
                        {
                            youCanSend = true;
                        }
                    }
                }
            }

            if (youCanSend)
            {
                foreach (var accounts in _storeContext.Account)
                {
                    if (whoShouldReciveMoney == accounts.IdUser)
                    {
                        accounts.Cash += moneyToSend;
                    }
                    else if (UserInformation.rememberMyId == accounts.IdUser)
                    {
                        accounts.Cash -= moneyToSend;
                    }
                }
                Console.WriteLine("Money sended");
                _storeContext.SaveChanges();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void WithdrawMoney()
        {
            Console.Write("How much money withdraw you want: ");
            moneyToWithdraw = Convert.ToDecimal(Console.ReadLine());
            if (moneyToWithdraw > 0)
            {
                foreach (var account in _storeContext.Account)
                {
                    account.Cash -= moneyToWithdraw;
                }
                _storeContext.SaveChanges();
                Console.WriteLine($"Get out of the depository {moneyToWithdraw} PLN");
            }
            else
            {
                Console.WriteLine("You can't withdraw");
            }
            Console.ReadKey();
            Console.Clear();
            
        }

        public void SetStoreContext(StoreContext storeContext) =>  _storeContext = storeContext;
    }
}

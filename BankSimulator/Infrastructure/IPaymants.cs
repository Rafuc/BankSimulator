using BankSimulator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulator.Infrastructure
{
    interface IPaymants
    {
        void Transfer();
        void MyTransactions();
        void CurrentlyCash();
        void DepositMoney();
        void WithdrawMoney();
        void SetStoreContext(StoreContext storeContext);
    }
}

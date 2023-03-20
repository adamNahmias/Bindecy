using System;
using Bindecy.Objects;

namespace Bindecy.Interfaces
{
    public interface IBankAccountManager
    {
        public Dictionary<int, BankAccount> Accounts { get; }
        BankAccount CreateAccount(int startAmount = 0);
        void DeleteAccount(BankAccount account);
        void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount);
    }
}

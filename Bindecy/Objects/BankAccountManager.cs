using Bindecy.Interfaces;

namespace Bindecy.Objects
{
    public class BankAccountManager : IBankAccountManager
    {
        Dictionary<int, BankAccount> accounts;
        int nextAccountID;

        public BankAccountManager()
        {
            accounts = new Dictionary<int, BankAccount> { };
            nextAccountID = 0;
        }
        public Dictionary<int, BankAccount> Accounts => accounts;
        public BankAccount CreateAccount(int startAmount = 0)
        {
            int accountID = nextAccountID++;
            BankAccount account = new BankAccount(accountId: accountID, startAmount: startAmount);
            accounts[accountID] = account;
            return account;
        }

        public void DeleteAccount(BankAccount account)
        {
            accounts.Remove(account.AccountID);
        }

        public void Transfer(BankAccount fromAccount, BankAccount toAccount, decimal amount)
        {
            fromAccount.Withdraw(amount, isTransfer: true);
            toAccount.Deposit(amount, isTransfer: true);
        }
    }
}

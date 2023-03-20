using Bindecy.Objects;

namespace Bindecy.Interfaces
{
    public interface IBankAccount
    {
        decimal Balance { get; }
        void Deposit(decimal amount, bool isTransfer = false);
        void Withdraw(decimal amount, bool isTransfer = false);
        IEnumerable<ITransaction> GetTransactionHistory();
        int AccountID { get; }
    }
}

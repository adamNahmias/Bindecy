using Bindecy.Objects;

namespace Bindecy.Interfaces
{
    public interface ITransaction
    {
        decimal Amount { get; }
        DateTime Timestamp { get; }
        TransactionType TransactionType { get; }
    }
}

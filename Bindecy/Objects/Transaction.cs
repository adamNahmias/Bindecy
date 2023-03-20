using Bindecy.Interfaces;

namespace Bindecy.Objects
{
    public enum TransactionType
    {
        Withdraw,
        Deposit,
        Transfer
    }
    public class Transaction : ITransaction
    {
        decimal amount;
        DateTime date;
        TransactionType transactionType;

        public Transaction(decimal amount, DateTime date, TransactionType type)
        {
            this.amount = amount;
            this.date = date;
            transactionType = type;
        }
        public decimal Amount => amount;

        public DateTime Timestamp => date;

        public TransactionType TransactionType => transactionType;

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", date, amount.ToString(), transactionType.ToString());
        }
    }
}

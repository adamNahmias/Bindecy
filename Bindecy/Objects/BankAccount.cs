using Bindecy.Interfaces;

namespace Bindecy.Objects
{
    public class BankAccount : IBankAccount
    {
        decimal totalAmount;
        int accountID;
        List<Transaction> transactions;
        public BankAccount(int accountId, int startAmount)
        {
            transactions = new List<Transaction>();
            accountID = accountId;
            totalAmount = startAmount;  
        }
        public int AccountID => accountID;

        public decimal Balance => totalAmount;
        public void Deposit(decimal amount, bool isTransfer = false)
        {
            totalAmount += amount;
            TransactionType Transactiontype = isTransfer ? TransactionType.Transfer : TransactionType.Deposit;
            transactions.Add(new Transaction(amount:amount, date: DateTime.Now, type: Transactiontype));
        }
        public void Withdraw(decimal amount, bool isTransfer=false)
        { 
            totalAmount -= amount;
            TransactionType Transactiontype = isTransfer ? TransactionType.Transfer : TransactionType.Withdraw;
            transactions.Add(new Transaction(amount: amount, date: DateTime.Now, type: Transactiontype));
        }
        public IEnumerable<ITransaction> GetTransactionHistory()
        {
            return transactions;
        }
    }
}

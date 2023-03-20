using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bindecy.Objects;
using System.Linq;
using System.Security.Cryptography;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void createAccount()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            bankAccountManager.CreateAccount();
            Assert.AreEqual(bankAccountManager.Accounts.Count, 1);  
        }

        [TestMethod]
        public void DepositMoney()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount:0);
            ac.Deposit(500);
            Assert.AreEqual(ac.Balance, 500);   
        }

        [TestMethod]
        public void WithdrawMoney()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount: 1000);
            ac.Deposit(300);
            Assert.AreEqual(ac.Balance, 700);
        }

        [TestMethod]    
        public void TransferMoney()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount: 1000);
            BankAccount ac2 = bankAccountManager.CreateAccount(startAmount: 1000);
            bankAccountManager.Transfer(ac, ac2, 200);
            Assert.AreEqual(ac.Balance, 800);
            Assert.AreEqual(ac2.Balance, 1200);

        }
        [TestMethod]    
        public void deleteAccount()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac =bankAccountManager.CreateAccount();
            Assert.AreEqual(bankAccountManager.Accounts.Count, 1);
            bankAccountManager.DeleteAccount(ac);
            Assert.AreEqual(bankAccountManager.Accounts.Count, 0);
        }

        [TestMethod]
        public void TransferTransaction()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount: 1000);
            BankAccount ac2 = bankAccountManager.CreateAccount(startAmount: 1000);
            bankAccountManager.Transfer(ac, ac2, 200);
            Assert.AreEqual(ac.GetTransactionHistory().First().TransactionType, TransactionType.Transfer);
        }

        [TestMethod]
        public void WithdrawTransaction()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount: 1000);
            ac.Withdraw(500);
            Assert.AreEqual(ac.GetTransactionHistory().First().TransactionType, TransactionType.Withdraw);
        }

        [TestMethod]
        public void DepositTransaction()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount: 1000);
            ac.Deposit(500);
            Assert.AreEqual(ac.GetTransactionHistory().First().TransactionType, TransactionType.Deposit);
        }

        [TestMethod]
        public void negativeBalance()
        {
            BankAccountManager bankAccountManager = new BankAccountManager();
            BankAccount ac = bankAccountManager.CreateAccount(startAmount: 500);
            ac.Withdraw(800);
            Assert.AreEqual(ac.Balance, -200);

        }
    }
}

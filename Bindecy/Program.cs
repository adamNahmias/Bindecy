
using Bindecy.Objects;
using System.Runtime.InteropServices;

Console.WriteLine(DateTime.Now);
BankAccountManager manager = new BankAccountManager();
BankAccount ac = manager.CreateAccount();
BankAccount ac2 = manager.CreateAccount();
ac.Withdraw(1500);
ac.Deposit(800);
ac2.Deposit(1000);
Console.WriteLine(ac.Balance);
manager.Transfer(ac2, ac, 500);
Console.WriteLine(ac.Balance);
Console.WriteLine(ac2.Balance);
foreach (Transaction a in ac.GetTransactionHistory()){
    Console.WriteLine(a.ToString());
}
foreach (Transaction a in ac2.GetTransactionHistory())
{
    Console.WriteLine(a.ToString());
}



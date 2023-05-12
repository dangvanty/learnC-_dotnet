// See https://aka.ms/new-console-template for more information
using Classes;


try
{
    var account = new BankAccount("<name",1000);

account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.GetAccountHistory());
Console.WriteLine(account.Balance);
account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}
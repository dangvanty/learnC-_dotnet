namespace Classes;
public class BankAccount
{
  private static int accountNumberSeed = 1234567890;
  private List<Transaction> allTransactions = new List<Transaction>();
  public string Number {get;}
  public string Owner {get; set;}
  public decimal Balance {
    get
      {
        decimal balance = 0; 
        foreach (var item in allTransactions)
        { 
          balance+=item.Amount;          
        }
        return balance;
      }
    
  }
  public BankAccount(string name, decimal initialBalance){
    Number = accountNumberSeed.ToString();
    accountNumberSeed++;

    Owner = name;
    MakeDeposit(initialBalance,DateTime.Now, "Intial balance");
  }
  public void MakeDeposit(decimal amount, DateTime date, string note)
  {
    if(amount<=0)
    {
      throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrawal must be positive" );
    }
    var deposit = new Transaction(amount,date,note);
    allTransactions.Add(deposit);
    
  }

  public void MakeWithdrawal(decimal amount, DateTime date, string note)
  {
    if(amount<=0)
    {
      throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdrawal must be positive");

    }
    if(Balance - amount < 0){
      throw new InvalidOperationException("Not sufficient funds for this withdrawal");
    }
    var withdrawal = new Transaction(-amount, date, note);
    allTransactions.Add(withdrawal);

  }

  public string GetAccountHistory(){
    // log console: 
    // var report = new System.Text.StringBuilder();
    // decimal balance = 0;
    // report.AppendLine("Date\t\tAmount\tBalance\tNote");
    // foreach(var item in allTransactions)
    // {
    //   balance += item.Amount;
    //   report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
    // }
    // return report.ToString();

    // ghi vao file
    string filePath = "test.txt";
    // string[] lines = File.ReadAllLines(FilePath)
    string[] lines=new string[allTransactions.Count]; 

    decimal balance = 0;
    for (int i= 0; i < allTransactions.Count; i++)
    {
      balance += allTransactions[i].Amount;
      lines[i] = allTransactions[i].Date.ToShortDateString()+"\t"+allTransactions[i].Amount+"\t"+balance+"\t"+allTransactions[i].Notes ; 
      Console.WriteLine("nhucc"+lines[i]);
    }
    File.WriteAllLines(filePath, lines);
    return "";
}
}


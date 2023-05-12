namespace virtuals
{
  class Person
  {
    protected string Name{set;get;}
    public  void showInfo ()
    {
      Console.WriteLine($"show name {Name}");
    }

  }

  class Worker : Person
  {
    public void setName()=>Name="CongNhan";
    public void showInfo()
    {
      Console.WriteLine("ok luon");
      base.showInfo();
    }
  }
  
}
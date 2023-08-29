namespace TestTryCatch
{
  class NameIsEmpty : Exception
  {
    public NameIsEmpty ():base("Name is not allowed empty!")
    {

    }
  }
  class AgeIsException : Exception
  {
    public int age{set;get;}
    public AgeIsException (int _age):base("Name is not exception!")
    {
      age = _age;
    }
    //public override string HelpLink { get => "http://google.com" }
    public void Detail ()
    {
      Console.WriteLine($"Lỗi tuổi bạn nhập {age} không nằm trong khoảng [18,100]");
    }
  }
}
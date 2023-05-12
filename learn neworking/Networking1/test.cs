namespace TestVoVan
{
  class Person
  {
    string name = "ok";
    public virtual void show()
    {
      Console.WriteLine($"{name}");
    }
  }
  class Student : Person
  {
    public static void ok ()
    {
      Console.WriteLine("thdkfj");
    }
    public override void show()
    {
      Console.WriteLine("nice");
    }
  }
}
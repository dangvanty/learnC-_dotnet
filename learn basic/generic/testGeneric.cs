namespace TestGeneric
{
  class Generic
  {
    public class ArrayTest<Tes>
    {
      public Tes Name{set;get;}
      public void ShowName()
      {
        Console.WriteLine($"ten la {this.Name}");
      }
      
    }
  }
}
using LibMorong;

namespace pthucmorong
{
  static class abc
  {
    public static void Print(this string s, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      Console.WriteLine(s);
    }
  }
  class testpthumorong
  {
    public static void Test()
    {
      int [] mang = {1,24,5,65};
      int max = mang.Max();
      Console.WriteLine("Max   "+max);
    }

    public static void Print (string s, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      Console.WriteLine(s);
    }
    public static void Test1()
    {
      string s = "Mai la bro";
      Print(s, ConsoleColor.Red);
      Print(s, ConsoleColor.Blue);
      s.Print(ConsoleColor.Green);

    }
    public static void Test2()
    {
      int s = 900;
      Console.WriteLine(s.InToString());
      Console.WriteLine(9.BinhPhuong());
      Console.WriteLine(9.89.InToString());
      
    }
   
  }
  
}
using System.Diagnostics;

namespace TestTryCatch
{
  partial class TryCatch
  {
    public static void Test1()
    {
      string path = null;
      try{
      string s = File.ReadAllText(path);
      Console.WriteLine(s);
      }
      catch (FileNotFoundException fn){
        Console.WriteLine(fn.Message);
        Console.WriteLine("File ko tồn tại");
      }
      catch (ArgumentNullException anE){
        Console.WriteLine(anE.Message);
        Console.WriteLine("file không được null");
      }
      catch (Exception e){
        Console.WriteLine(e);
      }
      
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Kết thúc");
        Console.ResetColor();
    }

    public static void CheckTuoi(int age)
    {
      if(age<18 || age>100)
      {
        Console.WriteLine(":::::::");
        throw new AgeIsException(age);
      }
      Console.WriteLine($"Tuổi của bạn là {age}");
    }
    public static void Test2(int age)
    {
      try
      {
        
        CheckTuoi(age);
      }
      catch(AgeIsException ageE)
      {
        Console.WriteLine(ageE.Message);
        ageE.Detail();
        //Console.WriteLine(ageE.HelpLink);
      }
      catch (Exception e)
      {
        
        Console.WriteLine(e.Message);
      }
      
    }
    public static void TestUnboxingAndBoxing()
    {
      // Boxing
      Stopwatch _stopWatch1 = new Stopwatch();
      _stopWatch1.Start();
      for(int i = 0; i < 1000000; i++)
      {
        Boxing();
      }
      _stopWatch1.Stop();
      

      // UnBoxing
      Stopwatch _stopWatch2 = new Stopwatch();
      _stopWatch2.Start();
      for(int i = 0; i < 1000000; i++)
      {
        UnBoxing();
      }
      _stopWatch2.Stop();
      

      // WithoutBoxingAndUnBoxing
      Stopwatch _stopWatch3 = new Stopwatch();
      _stopWatch3.Start();
      for(int i = 0; i < 1000000; i++)
      {
        WithoutBoxingAndUnBoxing();
      }
      _stopWatch3.Stop();

      Console.WriteLine($"Thời gian của task1 - boxing là :::: {_stopWatch1.ElapsedMilliseconds} - MS");
      Console.WriteLine($"Thời gian của task2 - unboxing là :::: {_stopWatch2.ElapsedMilliseconds} - MS");
      Console.WriteLine($"Thời gian của task3 - withoutBoxingAndUnBoxing là :::: {_stopWatch3.ElapsedMilliseconds} - MS");

        
    }
    public static void Boxing()
    {
      int a = 9;
      object b = a;
    }
    public static void UnBoxing()
    {
      object a = 9;
      int b = (int)a;
    }
    public static void WithoutBoxingAndUnBoxing()
    {
      int a = 9;
      int b = a;

    }
  }

}
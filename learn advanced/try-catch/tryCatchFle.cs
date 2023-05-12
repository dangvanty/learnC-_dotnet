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
    public static void Test2()
    {
      try
      {
        CheckTuoi(1);
      }
      catch(AgeIsException ageE)
      {
        Console.WriteLine(ageE.Message);
        ageE.Detail();
      }
      catch (Exception e)
      {
        
        Console.WriteLine(e.Message);
      }
      
    }
  }

}
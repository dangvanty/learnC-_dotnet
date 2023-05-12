namespace TestTryCatch
{
  partial class TryCatch
  {
    public static void Test()
    {
      try
      {
       int a = 9;
       int b = 0; 
       var c = a/b;
       Console.WriteLine(c);
      }
      catch (DivideByZeroException d)
      {
        Console.WriteLine("Bị lỗi nè");
      }
      catch (Exception e)
      {
        Console.WriteLine("Lỗi:::::"+e.Message);
        Console.WriteLine("Trace :::: "+e.StackTrace);
        Console.WriteLine("Type name ::::::::"+e.GetType().Name);
      }
    }
  }
}
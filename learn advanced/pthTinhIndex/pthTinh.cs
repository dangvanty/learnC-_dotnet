namespace PthTinhIndex
{
  class CountNumber
  {
    public static int number = 0;
    public static void Info()
    {
      Console.WriteLine($"Số lần truy cập {number}");
    }
    public void Count()
    {
      number ++;
    }
  }
  partial class PthTinhIndexTest
  {
    public static void Test()
    {
      CountNumber count1 = new CountNumber();
      CountNumber count2 = new CountNumber();

      count1.Count();
      count2.Count();
      CountNumber.Info();

    }
  }
}
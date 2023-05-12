namespace lambdaTest
{
  partial class TestLambda
  {
    public static void testLamFunc()
    {
      Func<int,int,int> tinhTong;
      tinhTong = (int a, int b )=>a+b;
      int kq = tinhTong(3,5);
      Console.WriteLine($"Ket qua test : {kq}");
    }
    
  }
}

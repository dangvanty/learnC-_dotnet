namespace Testqq{
  class testRefOut
{
  struct Truct {
    public Truct (){
      Console.WriteLine("nhuw quuu vaayj may");
    }
  }
  internal static void Test(int a, ref int n){
    Console.WriteLine($"a là {a}");
    Console.WriteLine("n:::"+n);
    n-=5;
    if(n>0){
    Test(a,ref n);
    }
    
  }
  public static void Clm(){
    Truct a = new Truct();
  }

}

}
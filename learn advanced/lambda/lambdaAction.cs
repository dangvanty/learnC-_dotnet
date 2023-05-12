namespace lambdaTest
{
  partial class TestLambda
  {
    public static void testLamAction()
    {
      Action<string> show;
      show = (string name)=>Console.WriteLine($" show name nè: {name}");
      show?.Invoke("okla");
    }
  }
  
}
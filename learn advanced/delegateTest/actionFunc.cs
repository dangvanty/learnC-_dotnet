namespace actionOkFunc

{
  class actionOkFuncTest
  {
    public static string showName(string name)
    {
      return $"name {name}";
    }
    public static void hii(string okla)
    {
      Console.WriteLine($"thong bao ne:::"+okla);
    }
    public static void Showall()
    {
      Func<string,string> ok;
      ok= showName;
      Console.WriteLine(ok("qqqqqqq"));
    }
    public static void showAction ()
    {
      Action<string> testAc;
      testAc = hii;
      testAc += hii;
      testAc("noooooo");
    }

  }
}
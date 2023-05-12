namespace delegateTest
{
  class delegateTestNe
  {
    public delegate void Show(string name);
    public static void showIp(string name)
    {
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine("showIphone : "+name);
      Console.ResetColor();
    }
    public static void showSam (string name)
    {
      Console.ForegroundColor=ConsoleColor.DarkYellow;
      Console.WriteLine("showSam : "+name);
      Console.ResetColor();
    }
    public static void Showall()
    {
      Show show;
      show =showIp;
      show +=showSam;
      show += showSam;
      show += showIp;

      show("Dang van ty");
    }
  }
}
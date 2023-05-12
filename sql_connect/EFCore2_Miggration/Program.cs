using EFCore2_Miggration.Seed;
class Program
{
  static void Main(string[] arg)
  {
    // tao db:
    WebContextSeed.DropDatabase();
    // WebContextSeed.CreateDatabase();

  }
}
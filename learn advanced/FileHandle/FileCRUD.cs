namespace CS016_FilesDirectories
{
  class FileCRUD
  {
    public static void Test ()
    {
      string file = "abc.txt";
      Directory.CreateDirectory("Nice");
      Directory.Delete("Nice");
      // Console.WriteLine(ok);
    }
  }
}
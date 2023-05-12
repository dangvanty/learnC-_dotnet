namespace CS016_FilesDirectories
{
  class PathTest
  {
    public static void Test()
    {
      string path = "home";

      var path1 = Path.Combine(path,"Test.txt");
      Console.WriteLine(Path.DirectorySeparatorChar);
      Console.WriteLine("KKKK"+path1);

      string pathTest = "/home/abc/ReadMe.txt";
      var path2 = Path.ChangeExtension(pathTest,"md");
      Console.WriteLine(path2);
      var path3 = Path.GetDirectoryName(pathTest);
      Console.WriteLine(path3);

      Console.WriteLine();
    }
  }
}
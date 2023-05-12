namespace CS016_FilesDirectories
{
  class DirectoryTest
  {
    public static void Test()
    {
      string path = "delegateTest";
      bool checkExits = Directory.Exists(path);
      var files = Directory.GetFiles(path);
      if(checkExits)
      {
        Console.WriteLine($"Thu muc ton tai {Directory.GetParent}");
      }
      else{
        Console.WriteLine("Thư mục không tồn tại");
      }

      foreach (var file in files)
      {
        Console.WriteLine(file);
      }
    }
  }
}

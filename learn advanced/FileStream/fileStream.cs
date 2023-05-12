using System.IO;
using System.Text;
namespace FileStreamz
{
  class fileStream
  {
    public static void TestLyThuyet()
    {
      string filepath = "/mycode/2.txt";
      using var stream = new FileStream( path:filepath, mode: FileMode.Create, access: FileAccess.Write, share: FileShare.None);
      
      // luu du lieu
      byte[] buffer = {1,2,3};

      int offset = 0; // byte dau tien doc ra de luu
      int count = 3; // so luong byte ghi; 
      stream.Write(buffer,0,3);

      // doc du lieu 
      stream.Read(buffer,offset,count);

      // int, double, --> byte 
      int abc=1;
      var bytes_abc = BitConverter.GetBytes(abc);
      // bytes --> int, double
      BitConverter.ToInt32(bytes_abc,0);

      // string --> bytes 
      string s = "abc";
      var bytes_s= Encoding.UTF8.GetBytes(s);
      // bytes --> string 
      Encoding.UTF8.GetString(bytes_s,0,10);
    }
  }

}
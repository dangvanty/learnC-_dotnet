using System.IO;
using System.Text;
namespace FileStreamz
{
  class Products
  {
    public int ID{set;get;}
    public double Price{set;get;}
    public string Name{set;get;}

    public void Save (Stream stream)
    {
      // id -> 4 bytes
      var bytes_id = BitConverter.GetBytes(ID);
      stream.Write(bytes_id,0,4);

      // price -> 8 bytes
      var bytes_price = BitConverter.GetBytes(Price);
      stream.Write(bytes_price,0,8);

      // name --> name.length bytes
      var bytes_name = Encoding.UTF8.GetBytes(Name);
      // convert byte leng roi dua vao viet file
      var bytes_leng =  BitConverter.GetBytes(bytes_name.Length);
      stream.Write(bytes_leng,0,4);
      stream.Write(bytes_name,0,bytes_name.Length);

    }

    public void Restore (Stream stream)
    {
      // phuc hoi id:  id-int --> 4 bytes
      var bytes_id = new byte[4];
      stream.Read(bytes_id,0,4);
      ID = BitConverter.ToInt32(bytes_id,0);

      // phuc hoi price: price - 
      var bytes_price = new byte[8];
      stream.Read(bytes_price,0,8);
      Price = BitConverter.ToDouble(bytes_price,0);


      // phuc hoi name : phuc hoi leng roi phuc hoi name

      var bytes_leng = new byte[4];
      stream.Read(bytes_leng,0,4);
      var leng = BitConverter.ToInt32(bytes_leng,0);

      var bytes_name = new byte[leng];
      stream.Read(bytes_name,0,leng);
      Name = Encoding.UTF8.GetString(bytes_name,0,leng);
    }
  }

  class ThucHanhFTr
  {
    public static void Test()
    {
      string path = "FileStream/data.dat";
      if(!File.Exists(path)){
        File.Create(path);
      }
      
      using var stream = new FileStream(path: path, mode : FileMode.Open, access: FileAccess.Read, share: FileShare.Read);
      Products products = new Products();
        // products.ID = 90;
        // products.Price = 87879;
        // products.Name = "con chos ne";

      products.Restore(stream);
      Console.WriteLine($" ten {products.Name} gia {products.Price} id {products.ID}");
    }
  }

}
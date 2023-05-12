using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConnectMySql
{
  class TestConnectMySql
  {
    public static void Connect()
    {
      // TẠO CHUỖI KẾT NỐI bằng SqlConnectionStringBuilder
        var stringBuilder = new MySqlConnectionStringBuilder();
        stringBuilder["Server"] = "127.0.0.1";
        stringBuilder["Database"] = "learncsharp";
        stringBuilder["User Id"] = "root";
        stringBuilder["Password"] = "MYSQL_ROOT_PASSWORD";
        stringBuilder["Port"] = "3306";

        string sqlConnectionString = stringBuilder.ToString();
        var connection = new MySqlConnection(sqlConnectionString);
        Console.WriteLine($"{"ConnectionString ",17} : {stringBuilder}");
        Console.WriteLine($"{"DataSource ",17} : {connection.DataSource}");

          // Bắt sự kiện trạng thái kết nối thay đổi
        connection.StateChange += (object sender, StateChangeEventArgs e) =>
        {
          Console.WriteLine($"Kết nối thay đổi: {e.CurrentState}, trạng thái trước: " + $"{e.OriginalState}");
        };

        // mở kết nối
        connection.Open();
        // tra ve ten db khi ket noi mo
        Console.WriteLine("Ten db la:::"+connection.Database);
        // cach1 thiet lap truy van:::: (-1-)
        using DbCommand command1 = new MySqlCommand();
        command1.Connection = connection;

        command1.CommandText = "select * from Sanpham limit 5";

        var dataReader = command1.ExecuteReader();
        Console.WriteLine("\r\nCacSanPham");
        Console.WriteLine($"{"SanPhamId",10} {"TenSanPham"}");
        while (dataReader.Read())
        {
          Console.WriteLine($"{dataReader["SanphamID"],10} {dataReader["TenSanpham"]}");
        }

        // cach2 (-2-)
        // Dùng SqlCommand thi hành SQL  - sẽ  tìm hiểu sau
        // using (DbCommand command = connection.CreateCommand())
        // {
        //   // Câu truy vấn SQL
        //   command.CommandText = "select * from Sanpham Limit 5";
        //   var reader = command.ExecuteReader();
        //   // Đọc kết quả truy vấn
        //   Console.WriteLine("\r\nCÁC SẢN PHẨM:");
        //   Console.WriteLine($"{"SanphamID ",10} {"TenSanpham "}");
        //   while (reader.Read())
        //   {
        //     Console.WriteLine($"{reader["SanphamID"],10} {reader["TenSanpham"]}");
        //   }
        // }

        // Không dùng đến kết nối thì phải đóng lại (giải phóng)
        connection.Close();
    }

    public static void connectWithFileJson()
    {
      var configBuilder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())// file config ở thư mục hiện tại
                              .AddJsonFile("appconfig.json"); //nap config json
      var configRoot = configBuilder.Build();// Tạo configurationroot
      
      // var sqlStringConnect = configRoot["csdl:ketnoi1"];
      var sqlStringConnect = configRoot["ketnoi2"];

      var connect = new MySqlConnection(sqlStringConnect);
      connect.StateChange += (object sender, StateChangeEventArgs e)=>{
          Console.WriteLine($"ket noi thay doi {e.CurrentState} ; trang thai truoc {e.OriginalState}");
      };
      connect.Open();
      using (DbCommand command = connect.CreateCommand())
      {
        command.CommandText = "select * from cungcap";
        var reader = command.ExecuteReader();
        Console.WriteLine($"{"Ten day du",10}  {"Ten Lien he"}");
        while(reader.Read())
        {
          Console.WriteLine($"{reader["Tendaydu"],10}  {reader["TenLienhe"]}");
        }
      }

      
      connect.Close();
    }
  }
}
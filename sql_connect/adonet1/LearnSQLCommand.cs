using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ConnectMySql
{
  class ConnectConfig
  {
    private static string UrlMySqlCon ()
    {
      var mysqlconnect = new  ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appconfig.json");


      var mySqlStringConnect = mysqlconnect.Build();
      return mySqlStringConnect["csdl:ketnoi1"];
    } 
    public static void SelectCataIDMore(int cataID )
    {
      var urlConnect = UrlMySqlCon();
      var connectMySql = new MySqlConnection(urlConnect);

      connectMySql.Open();

      using (DbCommand command = connectMySql.CreateCommand())
      {
        command.CommandText="SELECT DanhmucID, TenDanhmuc from danhmuc WHERE DanhmucID >= @DanhmucID";
        var danhMucID = new MySqlParameter("DanhmucID",cataID);
        command.Parameters.Add(danhMucID);

        var mySqlReader = command.ExecuteReader(); // dùng khi trả về nhiều dòng dữ liệu

        // var mySqlReader = command.ExecuteScalar(); // dùng để trả về dòng 1 cột 1 
        // Console.WriteLine(mySqlReader);

        if(mySqlReader.HasRows)
        {
          while(mySqlReader.Read())
          {
            var DanhmucID = mySqlReader["DanhmucID"];
            var TenDanhMuc = mySqlReader.GetString(1);
            Console.WriteLine($"ID danhmuc:: {DanhmucID} - TenDanhmuc::: {TenDanhMuc}");
          }

        }else
        {
          Console.WriteLine("Không có dữ liệu nào");
        }

      }
      connectMySql.Close();
    }

    public static void SelectCungCapByID(int CungcapID)
    {
      var mysqlConnectStr = UrlMySqlCon();
      var connectMySQL = new MySqlConnection(mysqlConnectStr);

      connectMySQL.Open();
      using (DbCommand command = connectMySQL.CreateCommand())
      {

      command.CommandText = $"SELECT CungcapID, Tendaydu, Thanhpho FROM cungcap WHERE CungcapID >= {CungcapID}";

      var CungcapReader= command.ExecuteReader();

        if(CungcapReader.HasRows)
        {
          while(CungcapReader.Read())
          {
            var Cungcapid = CungcapReader["CungcapID"];
            var tendaydu = CungcapReader["Tendaydu"];
            var Thanhpho = CungcapReader[2];
            Console.WriteLine($"Mã cung cap: {Cungcapid,10}, Tên đầy đủ: {tendaydu,5}, Thành phố: {Thanhpho,10}");
          }
        }else{
          Console.WriteLine("Không có row nào cả");

        }
      }
      connectMySQL.Close();
    }

    public static void AddShiper(int IDShiper, string NameShipper, string PhoneShipper )
    {
      var connectUrl = UrlMySqlCon();
      var connectMySQL = new MySqlConnection(connectUrl);

      connectMySQL.Open();

      using(var command = connectMySQL.CreateCommand())
      {
        command.CommandText = $"INSERT INTO shippers VALUES({IDShiper},'{NameShipper}','{PhoneShipper}')";
        var kq=command.ExecuteNonQuery();
        Console.WriteLine("So dong tac dong::"+kq);
      }

      connectMySQL.Close();
    }
    public static void DeleteShipper(int IDShiper )
    {
      var connectUrl = UrlMySqlCon();
      var connectMySQL = new MySqlConnection(connectUrl);

      connectMySQL.Open();

      using(var command = connectMySQL.CreateCommand())
      {
        command.CommandText = $"DELETE FROM shippers WHERE shipperID= {IDShiper}";
        var kq=command.ExecuteNonQuery();
        Console.WriteLine("So dong tac dong::"+kq);
      }

      connectMySQL.Close();
    }
    public static void UpdateIDShipper(int IDShiper, int ValueUpDate)
    {
      var connectUrl = UrlMySqlCon();
      var connectMySQL = new MySqlConnection(connectUrl);

      connectMySQL.Open();

      using(var command = connectMySQL.CreateCommand())
      {
        command.CommandText = $"UPDATE  shippers SET shipperID={ValueUpDate} WHERE shipperID= {IDShiper}";
        var kq=command.ExecuteNonQuery();
        Console.WriteLine("So dong tac dong::"+kq);
      }

      connectMySQL.Close();
    }

    public static void CountShipper ()
    {
      var connectUrl = UrlMySqlCon();
      var connectMySQL = new MySqlConnection(connectUrl);
      connectMySQL.Open();
      using (DbCommand command = connectMySQL.CreateCommand())
      {
        command.CommandText="SELECT COUNT(1) FROM shippers";
        var kq =command.ExecuteScalar();
        Console.WriteLine("So shipper la:"+kq);
      }
      connectMySQL.Close();
    }
    public static void InforProductByID (int IDProduct)
    {
      var connectUrl = UrlMySqlCon();
      var connectMySQL = new MySqlConnection(connectUrl);
      connectMySQL.Open();
      using (DbCommand command = connectMySQL.CreateCommand())
      {
        // truyen kieu procedure:::

        command.CommandText="getProductInfo";
        command.CommandType=CommandType.StoredProcedure;

        var id = new MySqlParameter("@id",IDProduct);
        command.Parameters.Add(id);

        var kq =command.ExecuteReader();
        if(kq.HasRows)
        {
          kq.Read();
          // select SanphamID, TenSanpham, TenDanhMuc, MoTa
          var sanPhamID = kq[0];
          var TenSanPham = kq[1];
          var TenDanhMuc = kq[2];
          var Mota = kq[3];
          Console.WriteLine($"sanPhamID {sanPhamID}, TenSanPham: {TenSanPham}, TenDanhMuc: {TenDanhMuc}");
        }else
        {
          Console.WriteLine("Khong co san pham nao");
        }

      }
      connectMySQL.Close();
    }
  }  
}

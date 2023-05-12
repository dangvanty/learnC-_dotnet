using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace DataAdapterDataSet
{
  class LearnDataSetDA
  {
    private static string UrlConfig()
    {
      var configUrl = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appconfig.json");
      var urlroot=  configUrl.Build(); 
      return urlroot["ketnoi2"];
    }
    static void ShowTable (DataTable table)
    {
      // truy cap table name:;;
      Console.WriteLine($"Ten bang {table.TableName}");

      foreach (var clm in table.Columns)
      {
        Console.Write($"{clm,10}");
        
      }
      Console.WriteLine();

      // var rowsLen = table.Rows.Count;
      // for (int i = 0; i < rowsLen; i++)
      // {
      //   Console.WriteLine($"{table.Rows[i][0],10} {table.Rows[i][1],10} {table.Rows[i][2],10}");
      // }
      foreach (DataRow row in table.Rows)
      {
        // Console.WriteLine($"{row[0],10} {row[1],10} {row[2],10}");
        for (int i = 0; i < table.Columns.Count; i++)
        {
         Console.Write($"{row[i],10}");
        }
        Console.WriteLine();
      }
    }
    public static void TestDataSet()
    {
      var mySqlUrl = UrlConfig();
      var connectMysql = new MySqlConnection(mySqlUrl);
      connectMysql.Open();

      var dataSet = new DataSet();

      // dataset.Table ; 
      var table = new DataTable("MyTable");
      dataSet.Tables.Add(table);

      // them cot cho bang
      table.Columns.Add("STT");
      table.Columns.Add("Hoten");
      table.Columns.Add("Tuoi");

      // them gia tri dong:

      table.Rows.Add(1,"TyNe",29);
      table.Rows.Add(1,"Okla",26);
      table.Rows.Add(1,"Tony",90);

      
      ShowTable(table);
      Console.WriteLine("Gia tri:"+(table.Rows[2][2]== null));
      connectMysql.Close();

    }
    public static void TestDatAdapterSELECT()
    {
      var urlConnect = UrlConfig();
      var connectMySQL = new MySqlConnection(urlConnect);
      connectMySQL.Open();

      var adapter = new MySqlDataAdapter();
      adapter.TableMappings.Add("Table","Nhanvien");

      //SelectCommand --> de adapter lay dc du lieu:
      string query = "SELECT NhanviennID, Ten, Ho FROM Nhanvien"; 
     
      adapter.SelectCommand = new MySqlCommand(query,connectMySQL);
      

      var dataSet = new DataSet();
      // do du lieu vao dataset; ==> tao ra bang Nhanvien trong dataset
      adapter.Fill(dataSet);

      DataTable tableNV = dataSet.Tables["Nhanvien"];
      ShowTable(tableNV);
      connectMySQL.Close();
    }
    public static void TestDatAdapterINSERT()
    {
      var urlConnect = UrlConfig();
      var connectMySQL = new MySqlConnection(urlConnect);
      connectMySQL.Open();

      var adapter = new MySqlDataAdapter();
      adapter.TableMappings.Add("Table","Nhanvien");

      //SelectCommand --> de adapter lay dc du lieu:
      string query1 = "SELECT NhanviennID, Ten, Ho FROM Nhanvien"; 
     
      adapter.SelectCommand = new MySqlCommand(query1,connectMySQL);
      
      string query = "INSERT INTO Nhanvien (Ho, Ten) VALUES(@Ho,@Ten)";
      adapter.InsertCommand= new MySqlCommand(query,connectMySQL);

      // them param
      adapter.InsertCommand.Parameters.Add("@Ho",MySqlDbType.VarChar,255,"Ho");
      adapter.InsertCommand.Parameters.Add("@Ten",MySqlDbType.VarChar,255,"Ten");

      // tao dataSet: 

      DataSet dataSet = new DataSet();
      adapter.Fill(dataSet);
      // lay table tu dataset;
      DataTable table = dataSet.Tables["Nhanvien"];


      var NhanvienInsert = table.Rows.Add();
      NhanvienInsert["Ho"]="Ho moi";
      NhanvienInsert["Ten"]="Ten moi";

      var kq =adapter.Update(dataSet);
      Console.WriteLine("So dong tac dong "+kq);


      connectMySQL.Close();
    }
    public static void TestDatAdapterDELETE()
    {
      var urlConnect = UrlConfig();
      var connectMySQL = new MySqlConnection(urlConnect);
      connectMySQL.Open();

      var adapter = new MySqlDataAdapter();
      adapter.TableMappings.Add("Table","Nhanvien");

      //SelectCommand --> de adapter lay dc du lieu:
      string query1 = "SELECT NhanviennID, Ten, Ho FROM Nhanvien"; 
     
      adapter.SelectCommand = new MySqlCommand(query1,connectMySQL);
      
      // DeleteCommand
      string query = "DELETE FROM Nhanvien WHERE NhanviennID = @NhanviennID";
      adapter.DeleteCommand= new MySqlCommand(query,connectMySQL);

      // them param
      var pr1 = adapter.DeleteCommand.Parameters.Add(new MySqlParameter("@NhanviennID",MySqlDbType.Int32));
      pr1.SourceColumn="NhanviennID";
      pr1.SourceVersion= DataRowVersion.Original;

      // tao dataSet: 

      DataSet dataSet = new DataSet();
      adapter.Fill(dataSet);

      // lay table tu dataset;
      DataTable table = dataSet.Tables["Nhanvien"];

      var NhanvienDelete = table.Rows[10];
      NhanvienDelete.Delete();

      var kq = adapter.Update(dataSet);
      Console.WriteLine("So dong tac dong "+kq);


      connectMySQL.Close();

    }
    public static void TestDatAdapterUPDATE()
    {
      var urlConnect = UrlConfig();
      var connectMySQL = new MySqlConnection(urlConnect);
      connectMySQL.Open();

      var adapter = new MySqlDataAdapter();
      adapter.TableMappings.Add("Table","Nhanvien");

      //SelectCommand --> de adapter lay dc du lieu:
      string query1 = "SELECT NhanviennID, Ten, Ho FROM Nhanvien"; 
     
      adapter.SelectCommand = new MySqlCommand(query1,connectMySQL);

      // UpdateCommand 
      string query = @"UPDATE Nhanvien SET Ten=@Ten, Ho=@Ho
                      WHERE NhanviennID=@NhanviennID
                      ";
      adapter.UpdateCommand = new MySqlCommand(query,connectMySQL);
      adapter.UpdateCommand.Parameters.Add("@Ten",MySqlDbType.VarChar,255,"Ten");
      adapter.UpdateCommand.Parameters.Add("@Ho",MySqlDbType.VarChar,255,"Ho");
      var pr1 = adapter.UpdateCommand.Parameters.Add(new MySqlParameter("@NhanviennID",MySqlDbType.Int32));
      pr1.SourceColumn="NhanviennID";
      pr1.SourceVersion=DataRowVersion.Original;

      // do du lieu vao dataset
      DataSet dataSet = new DataSet();
      adapter.Fill(dataSet);
      DataTable table=dataSet.Tables["Nhanvien"];

      // cap nhat dong 10; log dong --> tu 0 -> n-1
      var NhanvienUpdate = table.Rows[10];
      NhanvienUpdate["Ten"]="Ttony";
      NhanvienUpdate["Ho"]="DanTe";
      var kq =adapter.Update(dataSet);
      Console.WriteLine("So dong tac dong: "+kq);
      ShowTable(table);
      connectMySQL.Close();
    }
  }
}
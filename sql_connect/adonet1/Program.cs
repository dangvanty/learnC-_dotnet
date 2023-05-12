using ConnectMySql;
using DataAdapterDataSet;

class Program
{
  static void Main(string[] arg)
  {
    // ket noi sqlServer --> cài package system.datasqlclient
    // string sqlStringConnection = "Data Source=DESKTOP-D7VD2FS;database=xtlab;integrated security =True";
    // using var connection = new SqlConnection(sqlStringConnection);

    // // xem trạng thái connect;
    // Console.WriteLine(connection.State);

    // connection.Open();
    // // .. truy van

    // connection.Close();

    // connect Mysql;
    // TestConnectMySql.Connect();
    // TestConnectMySql.connectWithFileJson();


    // ConnectConfig.SelectCataIDMore(5);
    // ConnectConfig.SelectCungCapByID(10);
    // ConnectConfig.AddShiper(IDShiper:90,NameShipper:"DangVan",PhoneShipper:"9808080");
    // ConnectConfig.DeleteShipper(90);
    // ConnectConfig.UpdateIDShipper(IDShiper:90,ValueUpDate:4);
    // ConnectConfig.CountShipper();
    // ConnectConfig.InforProductByID(3);


    // LearnDataSetDA.TestDataSet();
    // LearnDataSetDA.TestDatAdapterSELECT();
    // LearnDataSetDA.TestDatAdapterINSERT();
    // LearnDataSetDA.TestDatAdapterDELETE();
    LearnDataSetDA.TestDatAdapterUPDATE();

  }

}
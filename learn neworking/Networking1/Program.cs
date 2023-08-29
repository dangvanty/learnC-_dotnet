// Chạy một HTTP Server, prefixes example: new string[] { "http://*:8080/" }
using System.Net;
using MyHttpLib;
using TienIchNetworking;
using TestVoVan;

class Program
{
  // static async Task Main(string[] args)
  // {
  //   var server = new MyHttpServer(new string[] {"http://localhost:4000/"});
  //   await server.StartAsync();
  // }
  static void Main(string[] args)
  {
   UriUriBuilder.ShowUriInfo("https://xuanthulab.net/abc/testpate.html?read=1#testfragment");
  //  UriUriBuilder.IPAddressExample("xuanthulab.net");
   IPAddress ip = IPAddress.Parse("127.0.0.1");
    int port = 1950;            
   UriUriBuilder.StartConnectAsync(ip,port).Wait();

  }
}

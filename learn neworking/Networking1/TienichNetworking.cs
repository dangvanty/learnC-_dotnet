using System.Net;
using System.Net.Sockets;

namespace TienIchNetworking
{
  class UriUriBuilder
  {
    public static void ShowUriInfo(string url) {
      Uri uri = new Uri(url);
      Console.WriteLine(url);
      Console.WriteLine($"Scheme   : {uri.Scheme}");
      Console.WriteLine($"Host     : {uri.Host}");
      Console.WriteLine($"Port     : {uri.Port}");
      Console.WriteLine($"Fragment : {uri.Fragment}");
      Console.WriteLine($"Query    : {uri.Query}");
      Console.WriteLine($"Path     : {uri.LocalPath}");
      foreach (var seg in uri.Segments)
          Console.WriteLine($"           {seg}");
      /*
      https://xuanthulab.net/abc/testpate.html?read=1#testfragment
      Scheme   : https
      Host     : xuanthulab.net
      Port     : 443
      Fragment : #testfragment
      Query    : ?read=1
      Path     : /abc/testpate.html
              /
              abc/
              testpate.html
      */
    }
    public static void BuildUriExample() {
      UriBuilder uriBuilder = new UriBuilder();
      uriBuilder.Host = "xuanthulab.net";
      uriBuilder.Port = 80;
      uriBuilder.Path = "path/to/site";
      uriBuilder.Query = "lession=1";
      uriBuilder.Fragment = "xyz";
      Uri uri = uriBuilder.Uri;
      Console.WriteLine(uri);
        // http://xuanthulab.net/path/to/site?lession=1#xyz
    }
    public static void IPAddressExample(string ips) {
    IPAddress ipaddress;
    if (IPAddress.TryParse(ips, out ipaddress)) {
        Console.WriteLine($"Broadcast     {IPAddress.Broadcast}");
        Console.WriteLine($"Loopback      {IPAddress.Loopback}");
        Console.WriteLine($"AddressFamily {ipaddress.AddressFamily}");
        Console.WriteLine($"IP4           {ipaddress.MapToIPv4().ToString()}");
        Console.WriteLine($"IP6           {ipaddress.MapToIPv6().ToString()}");
        /*
            Broadcast     255.255.255.255
            Loopback      127.0.0.1
            AddressFamily InterNetwork
            IP4           192.168.0.66
            IP6           ::ffff:192.168.0.66
        */
    }
}
public static  async Task StartConnectAsync(IPAddress iPAddress, int Port) {

            try {
                using (var client = new TcpClient())
                {

                  await client.ConnectAsync(iPAddress, Port);
                  Console.WriteLine("Đã kết nối");

                  using (NetworkStream stream = client.GetStream())
                  using (StreamWriter writer = new StreamWriter(stream))
                  using (StreamReader reader = new StreamReader(stream))
                  {
                    writer.AutoFlush = true;
                    bool quite = false;
                    while (!quite) {
                      Console.Write("Nhập nội dung (time, exit):");
                      string mgs = Console.ReadLine();
                      if (mgs == "exit")
                          quite = true;

                      await writer.WriteLineAsync(mgs);
                      string mgs_receive = await reader.ReadLineAsync();
                      Console.WriteLine(mgs_receive);
                    }

                  }
                }
            } catch (Exception ex)
            {
              Console.WriteLine($"Lỗi {ex.GetType().Name}, Message: {ex.Message}");
            }
        }
  }
}

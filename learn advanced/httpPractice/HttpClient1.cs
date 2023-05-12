using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;

namespace httpClientTest
{
  class HttpClient1
  {
    public static void Test()
    {
      var url = "https://xuanthulab.net";
      var uri = new Uri(url);
      Console.WriteLine(uri.Host);

      var iphostentry = Dns.GetHostEntry(uri.Host);
      Console.WriteLine(iphostentry.HostName);
      iphostentry.AddressList.ToList().ForEach(ip=>{
        Console.WriteLine(ip);
      });

    }
    public static void TestPing()
    {
      var ping = new Ping();

      var pingReply = ping.Send("google.com.vn");

      Console.WriteLine(pingReply.Status);
      if(pingReply.Status == IPStatus.Success);
      {
        Console.WriteLine(pingReply.RoundtripTime);
        Console.WriteLine(pingReply.Address);
      }
    }
    static void ShowHeaders (HttpHeaders headers)
    {
      Console.WriteLine("Cac Header");
      foreach (var header in headers)
      {
      string value = string.Join(" ", header.Value);
      Console.WriteLine($" {header.Key,20} : {value}");
      }
      Console.WriteLine();
    }
    public static async Task<string> GetWebContent(string url)
    {
      using var httpClient = new HttpClient();
      try{
        // them Header vao Http Request
        httpClient.DefaultRequestHeaders.Add("Accept","text/html,application/xhtml+xml+json");

        HttpResponseMessage response = await httpClient.GetAsync(url);

        // Phat sinh Exception neu ma trang thai tra ve la loi
        response.EnsureSuccessStatusCode();

        if(response.IsSuccessStatusCode)
        {

          Console.WriteLine($"Tai thanh cong - statusCode {response.StatusCode} {response.ReasonPhrase}");
          //Doc thong tin header tra ve
          ShowHeaders(response.Headers);

          Console.WriteLine("Starting read data");

          // doc noi dung content tra ve
          string htmltext = await response.Content.ReadAsStringAsync();
          Console.WriteLine($"Nhan duoc {htmltext.Length} ky tu");
          Console.WriteLine();
          return htmltext;
        }else 
        {
          Console.WriteLine($"Loi - statusCode {response.StatusCode} {response.ReasonPhrase}");
          return null;
        }
      }catch(Exception e){
        Console.WriteLine(e.Message);
        return null;
      }
      
    }
    public static void Test2()
    {
      var htmltask = GetWebContent("https://google.com.vn");
      htmltask.Wait(); // Chờ tải xong
      // Hoặc wait htmltask; nếu chuyển Main thành async 
      
      var html = htmltask.Result;
      Console.WriteLine(html!=null ? html.Substring(0, 255): "Lỗi");
    }
    public static void Test1()
    {
      var url = "https://www.google.com/search?q=xuanthulab";
      var task = GetWebContent(url);
      task.Wait();
      var html = task.Result;
      Console.WriteLine(html);
    }
    public static async Task Test3()
    {
      // thiết lập 1 http request:::::
      using var httpClient = new HttpClient();
      

      var httpMessageRequest = new HttpRequestMessage();
        // cấu hình method, uri, header cho request
      httpMessageRequest.Method=HttpMethod.Get;
      httpMessageRequest.RequestUri= new Uri("https://google.com.vn");
      httpMessageRequest.Headers.Add("User-Agent","Mozilla/5.0");

      // nhận phản hồi khi gửi request tới uri trên 
      var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);

      ShowHeaders(httpResponseMessage.Headers);

      var html = await httpResponseMessage.Content.ReadAsStringAsync();
      httpResponseMessage.EnsureSuccessStatusCode();
      Console.WriteLine("jhkj",html);
      Console.ReadKey();
    }
    public static async Task Test4()
    {
      // thiết lập 1 http request:::::
      using var httpClient = new HttpClient();
      

      var httpMessageRequest = new HttpRequestMessage();
        // cấu hình method, uri, header cho request
      httpMessageRequest.Method=HttpMethod.Post;
      httpMessageRequest.RequestUri= new Uri("https://postman-echo.com/post");
      httpMessageRequest.Headers.Add("User-Agent","Mozilla/5.0");

      // httpMessageRequest.Content ==> Form html , file, ...
      // Post ==> form html;
      /*
        key1 =>value1 [input]
        key2 => [value2-1 , value2-2] [multi select]
      */

      var parameters = new List<KeyValuePair<string,string>>();
      parameters.Add(new KeyValuePair<string, string>("key1","value1"));
      parameters.Add(new KeyValuePair<string, string>("key2","value2-1"));
      parameters.Add(new KeyValuePair<string, string>("key2","value2-2"));

      var content = new FormUrlEncodedContent(parameters);
      httpMessageRequest.Content = content;

      // nhận phản hồi khi gửi request tới uri trên 
      var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);

      ShowHeaders(httpResponseMessage.Headers);

      var html = await httpResponseMessage.Content.ReadAsStringAsync();
      httpResponseMessage.EnsureSuccessStatusCode();
      Console.WriteLine("jhkj",html==null?"loi":html);
      Console.ReadKey();
    }
    public static async Task Test5()
    {
      // thiết lập 1 http request:::::
      using var httpClient = new HttpClient();
      

      var httpMessageRequest = new HttpRequestMessage();
        // cấu hình method, uri, header cho request
      httpMessageRequest.Method=HttpMethod.Post;
      httpMessageRequest.RequestUri= new Uri("https://postman-echo.com/post");
      httpMessageRequest.Headers.Add("User-Agent","Mozilla/5.0");

      // đính kieu json:
      string data = @"{
      'key1':'giatri1',
      'key2':'giatri2'
      }";
      Console.WriteLine(data);
      var content = new StringContent(data,Encoding.UTF8,"application/json");

      // var content = new FormUrlEncodedContent(parameters);
      httpMessageRequest.Content = content;

      // nhận phản hồi khi gửi request tới uri trên 
      var httpResponseMessage = await httpClient.SendAsync(httpMessageRequest);

      ShowHeaders(httpResponseMessage.Headers);

      var html = await httpResponseMessage.Content.ReadAsStringAsync();
      httpResponseMessage.EnsureSuccessStatusCode();
      Console.WriteLine("jhkj",html==null?"loi":html);
      Console.ReadKey();
    }
  }
} 
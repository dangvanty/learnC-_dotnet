using System.Net;

namespace httpClientTest
{
  class httpListenerCreate
  {
    public static async Task Test()
    {
      // Mảng chứ địa chỉ Http lắng nghe
      // http = giao thức http, * = ip bất kỳ, 8080 = cổng lắng nghe
      string[] prefixes = new string[]{"http://*:8080/"};
      HttpListener listener = new HttpListener();
      if(!HttpListener.IsSupported) throw new Exception ("Hệ thống không hỗ trợ HttpListener");
      if(prefixes == null || prefixes.Length == 0) throw new ArgumentException("prefixes");

      foreach (string s in prefixes)
      {
       listener.Prefixes.Add(s); 
      }

      Console.WriteLine("Server start ...");

      // http bắt đầu lắng nghe truy vấn gửi đến 
      listener.Start();
      // Vòng lặp chấp nhật và xử lý các client kết nối
      do
      {
        // Chấp nhận khi có client kết nối đển
        HttpListenerContext context = await listener.GetContextAsync();

        //...
        // Xử lý context - đọc thông tin request, ghi thông tin response
        // ... ví dụ như sau: 

        var response = context.Response;                                        // lấy HttpListenerResponse
        var outputstream = response.OutputStream;                               // lấy Stream lưu nội dung gửi cho client

        context.Response.Headers.Add("content-type", "text/html");              // thiết lập respone header
        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Hello world!");     // dữ liệu content
        response.ContentLength64 = buffer.Length;
        await outputstream.WriteAsync(buffer,0,buffer.Length);                  // viết content ra stream
        outputstream.Close();     
        
      } while (listener.IsListening);
    } 
  }
}
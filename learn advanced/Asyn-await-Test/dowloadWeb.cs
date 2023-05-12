namespace AsynAwaitTest
{
  partial class AsynAwait
  {
    static async Task<Object> GetWebDown(string url)
    {
     HttpClient httpClient = new HttpClient();
     Console.WriteLine("Bắt đầu tải");

     HttpResponseMessage kq = await httpClient.GetAsync(url);
     string content = await kq.Content.ReadAsStringAsync();
     return content;
    }
    public static async Task Test3()
    {
      var task = GetWebDown("https://xuanthulab.net");
      DoSomeThing(20,"T1",ConsoleColor.DarkGreen);
      var content = await task;
      Console.WriteLine(content);
      Console.ReadKey();
      
    }
  }
}
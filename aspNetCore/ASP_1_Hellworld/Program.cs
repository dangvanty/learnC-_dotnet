// var builder = WebApplication.CreateBuilder(args);
// Console.WriteLine("dkfjdkljldkfj"+builder.WebHost);
// var app = builder.Build();

// app.UseStaticFiles();
// app.UseStatusCodePages ();
// app.MapGet("/", () => "Hello Worldkjkjl!");
// // Bind query string values to a primitive type array.
// // GET  /tags?q=1&q=2&q=3
// app.MapGet("/tags", (int[] q) =>
//                       $"tag1: {q[0]} , tag2: {q[1]}, tag3: {q[2]}");


// app.Run();
namespace ASP_1_Hellworld
{
public class Program
  {
    public static void Main(string[] args)
    {
      // Build -  tạo các dịch vụ đã đăng ký trả về WebHost
      // Run - chạy ứng dụng web
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
            // webBuilder đối tượng lớp WebHostBuilder để cấu hình, đăng ký các dịch vụ ứng dụng Web
            // UseStartup chỉ ra lớp khởi chạy ứng dụng (đăng ký dịch vụ)
            webBuilder.UseWebRoot("public");
            webBuilder.UseStartup<Startup>();
          });
  }
}
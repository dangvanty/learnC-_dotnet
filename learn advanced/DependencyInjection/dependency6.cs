using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace DependencyInjection
{
  public class MyServiceOptions
  {
    public string Data1 {set;get;}
    public int Data2 {set;get;}
  }
  public class MyService 
  {
    public string Data1 {set;get;}
    public int Data2 {set;get;}

  // sau này thư viên sẽ quản lý các dep ở khu vực riêng và các ops ở khu vực riêng 
    public MyService(IOptions<MyServiceOptions> options)
    {
      var _options = options.Value;
      Data1 = _options.Data1;
      Data2 = _options.Data2;
    }

    public void PrintData ()
    {
      Console.WriteLine($"{Data1} / {Data2}");
    }
  }
  class DepenWithOption
  {
    public static void Test()
    {
      // đối tượng config... 
      var configBuilder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory()+@"\DependencyInjection")      // file config ở thư mục hiện tại
                       .AddJsonFile("appsettings.json");                  // nạp config định dạng JSON
      var configurationroot = configBuilder.Build();                            // Tạo configurationroot
      // var ke2 = configurationroot.GetSection("Option2").GetSection("Key2").Value;
      // Console.WriteLine("dfjldf:::::: "+ke2); đọc key 
      var sectionMyServiceOptions = configurationroot.GetSection("MyServiceOptions");
      var services = new ServiceCollection();
      services.AddSingleton<MyService>();

      // services.Configure<MyServiceOptions>(
      //   (MyServiceOptions options)=>{
      //     options.Data1="Xin chao";
      //     options.Data2=90;
      //   }
      // ); --> nạp trực tiếp bằng delegate
      services.Configure<MyServiceOptions>(sectionMyServiceOptions); // nạp từ file Json

      var provider = services.BuildServiceProvider();
      var mys= provider.GetService<MyService>();
      
      
      mys.PrintData();
      Console.WriteLine(Directory.GetCurrentDirectory()+@"\DependencyInjection");
      Console.WriteLine("----------------------");
     
    }
  }
}
namespace Razor1
{
  public class Program
  {
    public static void Main(string[]arg)
    {
      //Buil - tao cac dich vu da dang ky tra ve webhost
      /// Run - chay ung dung web
      CreateHostBuilder(arg).Build().Run();

    }
    public static IHostBuilder CreateHostBuilder(string[]arg)=>
      Host.CreateDefaultBuilder(arg)
          .ConfigureWebHostDefaults(webBuilder=>{

            /*webbuilder doi tuong lop wehostbuilder de cau hinh
            dang ky cac dich vu ung dung web
            UseStartup chi ra lop khoi chay ung dung (dang ky dich vu)            
            */
            // webBuilder.UseWebRoot("public");
            webBuilder.UseStartup<Startup>();
          });
  }
}
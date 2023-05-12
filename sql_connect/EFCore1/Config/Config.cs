using Microsoft.Extensions.Configuration;

namespace EFCore1.ConfigConnect
{
  class ConfigMySql
  {
   public static string UrlConfig()
    {
      var configUrl = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appconfig.json");
      var urlroot=  configUrl.Build(); 
      return urlroot["ketnoi2"];
    }
  }
}
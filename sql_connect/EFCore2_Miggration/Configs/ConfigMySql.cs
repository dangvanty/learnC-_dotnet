using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EFCore2_Miggration.Configs
{
  public class ConfigMySql
  {
    public static string UrlConfig()
    {
      var configUrl = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory()+"/Configs")
                        .AddJsonFile("appconfig.json");
      var urlroot=  configUrl.Build(); 
      return urlroot["ketnoi2"];
    }
  }
}
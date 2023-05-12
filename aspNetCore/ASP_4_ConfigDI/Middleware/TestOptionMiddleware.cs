using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_4_ConfigDI.Options;
using ASP_4_ConfigDI.Services;
using Microsoft.Extensions.Options;

namespace ASP_4_ConfigDI.Middleware
{
  public class TestOptionMiddleware : IMiddleware
  {
    TestOption _testOptions{set;get;}
    ProductName _productName {set;get;}
    public TestOptionMiddleware (IOptions<TestOption> options, ProductName productName)
    {
      _testOptions=options.Value;
      _productName = productName;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      var stringBuilder = new StringBuilder();

      stringBuilder.Append("TestOption middleware them vao \n");
      stringBuilder.Append(_testOptions.connect1+"\n");
      foreach (var item in _productName.GetName())
      {
        stringBuilder.Append(item+"\n");
      }

      await context.Response.WriteAsync(stringBuilder.ToString());
      await next(context);
    }
  }
}
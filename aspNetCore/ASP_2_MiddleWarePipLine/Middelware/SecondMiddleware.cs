using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_2_MiddleWarePipLine.Middelware
{
	// cần triển khai phương thức InvokeAync khi kế thừ IMiddleware
  public class SecondMiddleware : IMiddleware
  {

		/*
			Url: "/xxx.html"
				- Không gọi middleware phia sau
				- Bạn không được truy cập
				- Header-  SecondMiddleware : bạn không được truy cập

			Url: "/xxx.html" 
				-SecondMiddleware bạn được truy cập
				- Chuyển httpContext cho middleware phía sau
		*/
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
      bool checkMiddleware = context.Request.Path=="/xxx.html";
			if(checkMiddleware)
			{
				// Header cần phải config trước ; 

				context.Response.Headers.Add("Middelware2", "Ban khong duoc truy cap");

				var dataPreviousMiddleware= context.Items["FirstMiddleware"];
				if(dataPreviousMiddleware!=null)
					await context.Response.WriteAsync((string)dataPreviousMiddleware);
				await context.Response.WriteAsync("Ban khong duoc truy cap");
			}
			else{
				// await context.Response.WriteAsync("Ban duoc truy cap");
				context.Response.Headers.Add("Middelware2", "Ban duoc truy cap");
				await next(context);
			}
    }
  }
}
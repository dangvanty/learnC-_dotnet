using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_2_MiddleWarePipLine.Middelware
{
	public class FirstMiddleware
	{
		private readonly RequestDelegate _next;
		// RequestDelegate --> ~ async (HttpContext context)=>{}
		public FirstMiddleware(RequestDelegate next)
		{
			_next =next;
		}	

		// HttpContext di qua Middleware trong PipLine
		public async Task InvokeAsync (HttpContext context)
		{
			Console.WriteLine( $"URL::::::{context.Request.Path}");
			context.Items.Add("FirstMiddleware", DateTime.Now.ToString());
			// await context.Response.WriteAsync("<p>djfkdlf<p>");
			await _next(context);
		}


	}
}
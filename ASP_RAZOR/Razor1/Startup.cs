using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor1
{
	public class Startup
	{
		public void ConfigureServices (IServiceCollection services)
		{

		}	

		public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			
			app.UseStaticFiles();
			app.UseRouting();
			app.UseEndpoints(endpoints=>{
				endpoints.MapGet("/", async context=>{
					await context.Response.WriteAsync("hello world");
				});
			});
			app.Run(async context=>{
				await context.Response.WriteAsync("Dotnetne");
			});
		}	
	}
}
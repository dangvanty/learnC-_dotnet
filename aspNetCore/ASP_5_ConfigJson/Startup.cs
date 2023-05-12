using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_5_ConfigJson.Options;

namespace ASP_5_ConfigJson
{

	// xem thêm ở ASP_4 vì giống nhau 
    public class Startup
    {

      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
			{
				app.UseStaticFiles();
				// app.UseMiddleware<TestOptionMiddleware>();

				app.UseRouting();

				app.UseEndpoints(endpoints=>{
					endpoints.MapGet("/showOptions",async context =>{
						// interface Inconfiguration; configuration là dịch vụ được nạp chung với asp.net
						var configure = context.RequestServices.GetService<IConfiguration>();
						var testOption = configure.GetSection("TestOptions");
						var optionKey1 = testOption["opt_key1"];
						var k1 = testOption.GetSection("opt_key2")["k1"];

						var s = new StringBuilder();

						s.Append("Options Connect MySQL:::\n");
						s.Append($"{optionKey1} ::::option1");

						await context.Response.WriteAsync(s.ToString());
					});

					endpoints.MapGet("/showOptions1", async context =>{
						var configure = context.RequestServices.GetService<IConfiguration>();
						var testOption = configure.GetSection("TestOptions").Get<TestOption>();
						var s = new StringBuilder();

						s.Append("Options connect with Get TestOption \n");
						s.Append(testOption.opt_key1 + " :::option 1 \n ");
						s.Append(testOption.opt_key2.k1 + " :::option 2 - k1 \n");
						s.Append(testOption.opt_key2.k2 + " :::option 2 - k2 \n");

						await context.Response.WriteAsync(s.ToString());
					});
				});

				app.Run(async(context)=>{
					await context.Response.WriteAsync("Midlleware End");
				});
				app.UseStatusCodePages();
			}
			
    }
}
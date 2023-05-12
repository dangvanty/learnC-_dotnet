using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_2_MiddleWarePipLine.Middelware;

namespace ASP_2_MiddleWarePipLine
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
				// đối với loại middleware kế từ IMiddleware thì cần đăng ký tại đây: 
				services.AddSingleton<SecondMiddleware>();

		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// middleware static file
			app.UseStaticFiles();

			//UseMiddleware:::
			// app.UseMiddleware<FirstMiddleware>();

			// su dung phuong thuc mo rong 
			app.UseFirstMiddleware(); // Dua vao Pipeline Middleware. 

			// middleware 2: 
			app.UseSecondMiddleware();

			app.UseRouting();  // endpointing routing middleware 

			app.UseEndpoints((endpoint)=>{
				endpoint.MapGet("/trangchu.html", async(context)=>{
					await context.Response.WriteAsync("<h1>Đây là trang chủ</h1>");
				});
				endpoint.MapGet("/lienhe.html", async(context)=>{
					await context.Response.WriteAsync("<h1>Đây là trang liên hệ</h1>");
				});
			});
			// rẽ nhánh pipline
			app.Map("/admin",(IApplicationBuilder app1)=>{

				app1.UseRouting();
				app1.UseEndpoints((endpoint)=>{
					endpoint.MapGet("/user", async(context)=>{
						await context.Response.WriteAsync(" <h1>Trang user</h1>");
					});

					endpoint.MapGet("/dashboard", async(context)=>{
						await context.Response.WriteAsync("<h1>Trang Dashboard</h1>");
					});
				});

				//Terminal middleware M2
			app1.Run(async (context)=>{
				await context.Response.WriteAsync("Middleware end!!!! ADMIN ASP.NET");
			}); 
			});

			//Terminal middleware M1
			app.Run(async (context)=>{
				await context.Response.WriteAsync("Middleware end!!!! ASP.NET");
			}); 
		}

	}
}
/*
// pipline: M1 ==> chưa cho middleware; 
// pipline: firstMiddleware - M1 : khi cho middelware
// pipline: StaticFiles - firstMiddleware - M1 : khi cho middelware
*/
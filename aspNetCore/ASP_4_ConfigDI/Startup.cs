using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_4_ConfigDI.Middleware;
using ASP_4_ConfigDI.Options;
using ASP_4_ConfigDI.Services;
using Microsoft.Extensions.Options;

namespace ASP_4_ConfigDI
{
	public class Startup
	{
		IConfiguration _configuration;
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddTransient<TestOptionMiddleware>();
			services.AddSingleton<ProductName>();
			services.AddOptions();
			var configuration = _configuration.GetSection("ConnectionMySQL");
			services.Configure<TestOption>(configuration);
			//khi làm như dòng trên (26) thì trong có 1 đối tượng kiểu: <IOptions<TestOtion>>
			// sử dụng như dòng 71

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseStaticFiles();
			app.UseMiddleware<TestOptionMiddleware>();

			app.UseRouting();

			app.UseEndpoints(endpoints=>{
				endpoints.MapGet("/showOptions1",async context =>{
					// interface Inconfiguration; configuration là dịch vụ được nạp chung với asp.net
					var configure = context.RequestServices.GetService<IConfiguration>();
					var testOption = configure.GetSection("ConnectionMySQL");
					var connectStr = testOption["connect2"];

					var s = new StringBuilder();

					s.Append("Options Connect MySQL:::\n");
					s.Append(connectStr);

					await context.Response.WriteAsync(s.ToString());
				});
				endpoints.MapGet("/showOptions2",async context =>{
					// interface Inconfiguration; configuration là dịch vụ được nạp chung với asp.net
					var configure = context.RequestServices.GetService<IConfiguration>();

					// Chuyển đổi thành đối tượng vơi Get () 
					var testOption = configure.GetSection("ConnectionMySQL").Get<TestOption>();
					var connect1 = testOption.connect1;
					var connect2 = testOption.connect2;

					var s = new StringBuilder();

					s.Append("Options Connect MySQL:::\n");
					s.Append($" Connect 1 {connect1}::\n");
					s.Append($" Connect 2 {connect2}:::\n");

					await context.Response.WriteAsync(s.ToString());
				});
				endpoints.MapGet("/showOptions3",async context =>{
					var testOption = context.RequestServices.GetService<IOptions<TestOption>>().Value;
					var connect1 = testOption.connect1;
					var connect2 = testOption.connect2;

					var s = new StringBuilder();

					s.Append("Options Connect MySQL với depen Inject:::\n");
					s.Append($" Connect 1 {connect1}::\n");
					s.Append($" Connect 2 {connect2}:::\n");

					await context.Response.WriteAsync(s.ToString());
				});
			});

			app.Run(async(context)=>{
				await context.Response.WriteAsync("Midlleware End");
			});
		}
			
	}
}
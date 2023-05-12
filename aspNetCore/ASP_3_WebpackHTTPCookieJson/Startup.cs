using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _03.RequestResponse;

namespace ASP_3_WebpackHTTPCookieJson
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
				// đối với loại middleware kế từ IMiddleware thì cần đăng ký tại đây: 
				// services.AddSingleton<SecondMiddleware>();

		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// middleware static file
			app.UseStaticFiles();

			app.UseRouting();  // endpointing routing middleware 

			app.UseEndpoints((endpoints)=>{
				endpoints.MapGet ("/", async context => {
						string menu = HtmlHelper.MenuTop (HtmlHelper.DefaultMenuTopItems (), context.Request);
						string content = HtmlHelper.HtmlTrangchu ();
						string html = HtmlHelper.HtmlDocument ("Trang chủ", menu + content);
						await context.Response.WriteAsync (html);
				});

				endpoints.Map ("/RequestInfo", async context => {
						string menu = HtmlHelper.MenuTop (HtmlHelper.DefaultMenuTopItems (), context.Request);
						string requestinfo = RequestProcess.RequestInfo (context.Request).HtmlTag ("div", "container");
						string html = HtmlHelper.HtmlDocument ("Thông tin Request", (menu + requestinfo));
						await context.Response.WriteAsync (html);
				});

				endpoints.MapGet ("/Encoding", async context => {
						string menu = HtmlHelper.MenuTop (HtmlHelper.DefaultMenuTopItems (), context.Request);
						string htmlec = RequestProcess.Encoding (context.Request).HtmlTag ("div", "container");
						string html = HtmlHelper.HtmlDocument ("Encoding", (menu + htmlec));
						await context.Response.WriteAsync (html);
				});

				// Ngoài địa chỉ /Cookies thì các địa chỉ con cũng có thể truy cập được 
				endpoints.MapGet("/Cookies/{*action}", async (context) => {
						string menu     = HtmlHelper.MenuTop(HtmlHelper.DefaultMenuTopItems(), context.Request);
						string cookies  = RequestProcess.Cookies(context.Request, context.Response).HtmlTag("div", "container");
						string html    = HtmlHelper.HtmlDocument("Đọc / Ghi Cookies", (menu + cookies));
						await context.Response.WriteAsync(html);
				});
			});
			// Điểm rẽ nhánh pipeline khi URL là /Json
			app.Map ("/Json", app => {
					app.Run (async context => {
						string Json  = RequestProcess.GetJson();
						context.Response.ContentType = "application/json";
						await context.Response.WriteAsync(Json);
					});
			});

			// Điểm rẽ nhánh pipeline khi URL là /Form
			app.Map ("/Form", app => {
					app.Run (async context => {

						string menu = HtmlHelper.MenuTop (HtmlHelper.DefaultMenuTopItems (), context.Request);
						string formhtml = await RequestProcess.FormProcess (context.Request);
						formhtml = formhtml.HtmlTag ("div", "container");
						string html = HtmlHelper.HtmlDocument ("Form Post", (menu + formhtml));
						await context.Response.WriteAsync (html);
					});
			});


			//Terminal middleware M1
			app.Run(async (context)=>{
				await context.Response.WriteAsync("Middleware end!!!! ASP.NET");
			}); 
		}
	}
}
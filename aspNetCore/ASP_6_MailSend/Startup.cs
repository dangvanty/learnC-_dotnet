using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ASP_6_MailSend.Services;

namespace ASP_6_MailSend
{
    public class Startup
    {
			IConfiguration configure;
			public Startup (IConfiguration _configure)
			{
				configure = _configure;
			}
			public void ConfigureServices (IServiceCollection services)
			{
				// services.AddTransient<SendMailServices>();
				// Đăng ký SendMailService với kiểu Transient, mỗi lần gọi dịch
				// vụ ISendMailService một đới tượng SendMailService tạo ra (đã inject config)
				services.AddTransient<ISendMailService, SendMailServices>();

				services.AddOptions(); // Kích hoạt Options
				var configuration = configure.GetSection("MailSettings");  // đọc config
				services.Configure<MailServiceSettings>(configuration); // đăng ký để Inject
				
			}

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

					endpoints.MapGet("/sendmail", async context =>{
						var meagese = await MailUtils.MailUtils.SendMail("dangvantydh@gmail.com","dangvantydh@gmail.com", "Test net", "con tró này");
						await context.Response.WriteAsync($" thong bao ::: {meagese}");
					});
					endpoints.MapGet("/sendmailGoogle", async context =>{
						var meagese = await MailUtils.MailUtils.SendMailGoogle("dangvantydh@gmail.com","dangvantydh@gmail.com", "Test net", "hi chao cau","thanhchungneverdie@gmail.com","dfkwqmihsdqzwvpe" );
						await context.Response.WriteAsync($" thong bao ::: {meagese}");
					});
					endpoints.MapGet("/Config", async context =>{
						var MailSettings = context.RequestServices.GetService<IOptions<MailServiceSettings>>().Value;

						await context.Response.WriteAsync($" thong bao ::: {MailSettings.DisplayName}");
					});
					endpoints.MapGet("/SendMailz", async context =>{
						var sendMailServices = context.RequestServices.GetService<ISendMailService>();
						MailContent mailContent = new MailContent()
						{
							To= "dangvantydh@gmail.com",
							Subject = "Gửi mail nè",
							Body= @"<h1>hello</h1>
								<ul>
									<li>Con cho 1</li>
									<li>Con cho 2</li>
									<li>Con cho 3</li>
								</ul>"
						};
						var result = await sendMailServices.SendMail(mailContent);
						await context.Response.WriteAsync($" thong bao ::: {result}");
					});
					endpoints.MapGet("/SendMailtest", async context =>{
						var sendMailServices = context.RequestServices.GetService<ISendMailService>();
						MailContent mailContent = new MailContent()
						{
							To= "dangvantydh@gmail.com",
							Subject = "Gửi mail nè",
							Body= @"<h1>hello</h1>
								<ul>
									<li>Con cho 1</li>
									<li>Con cho 2</li>
									<li>Con cho 3</li>
								</ul>"
						};
						//  await sendMailServices.SendEmailAsync(
						// 	email:"dangvantydh@gmail.com", subject: "Gửi mail nè",
						// 	htmlMessage:@"<h1>hello</h1>
						// 		<ul>
						// 			<li>Con cho 1</li>
						// 			<li>Con cho 2</li>
						// 			<li>Con cho 3</li>
						// 		</ul>"
						// );
							var kq = await sendMailServices.SendMail(mailContent);
						await context.Response.WriteAsync($" thong bao ::: {kq}");
					});

				});

				app.Run(async(context)=>{
					await context.Response.WriteAsync("Midlleware End");
				});
				app.UseStatusCodePages();
			}
			
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ASP_6_MailSend.MailUtils
{
	public class MailUtils
	{
		public static  async Task<string> SendMail (string _from,string _to,string _subject, string _body)
		{
			MailMessage message = new MailMessage(_from,_to,_subject,_body);
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.SubjectEncoding=System.Text.Encoding.UTF8;
			message.IsBodyHtml = true;

			message.ReplyToList.Add(new MailAddress(_from)); // cấu hình danh sách reply 
			message.Sender = new MailAddress(_from, "TonyTeo"); // cấu hình người gửi mail

			using var smtClient = new SmtpClient("localhost");

			try
			{
				await smtClient.SendMailAsync(message);
				return "Gửi email thành công";
			}
			catch (System.Exception e)
			{
				Console.WriteLine(e.Message);
				return "Gửi email thất bại";
			}

		}	
		public static  async Task<string> SendMailGoogle (string _from,string _to,string _subject, string _body, 
		string _gmail, string _password)
		{
			MailMessage message = new MailMessage(_from,_to,_subject,_body);
			message.BodyEncoding = System.Text.Encoding.UTF8;
			message.SubjectEncoding=System.Text.Encoding.UTF8;
			message.IsBodyHtml = true;

			message.ReplyToList.Add(new MailAddress(_from)); // cấu hình danh sách reply 
			message.Sender = new MailAddress(_from, "TonyTeo"); // cấu hình người gửi mail

			using var smtClient = new SmtpClient("smtp.gmail.com");
			smtClient.Port=587;
			smtClient.EnableSsl=true;
			smtClient.Credentials=new NetworkCredential(_gmail,_password);

			try
			{
				await smtClient.SendMailAsync(message);
				return "Gửi email thành công";
			}
			catch (System.Exception e)
			{
				Console.WriteLine(e.Message);
				return "Gửi email thất bại";
			}

		}	
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ASP_6_MailSend.Services
{
	public class SendMailServices : ISendMailService
	{


    private  ILogger<SendMailServices> logger;
		MailServiceSettings mailSettings;

		// inject được nếu mailSetting đã configuge ở Start up 
		public SendMailServices(IOptions<MailServiceSettings> _mailSettings, ILogger<SendMailServices> _logger)
		{
			mailSettings = _mailSettings.Value;
			logger = _logger;
      logger.LogInformation("Create SendMailService");
		}
		public async Task<string> SendMail (MailContent mailContent)
		{
			var email = new MimeMessage();
			// email.Sender= new MailboxAddress("ten hien thi", " dia chỉ email");
			email.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
			email.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
			email.ReplyTo.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));

			email.To.Add(new MailboxAddress(mailContent.To,mailContent.To));
			email.Subject = mailContent.Subject;

			var builder = new BodyBuilder();
			builder.HtmlBody = mailContent.Body;

			// có thể gửi đi với file đính kèm, text body
			// builder.Attachments
			// builder.TextBody
			email.Body = builder.ToMessageBody();

			using var smtp = new MailKit.Net.Smtp.SmtpClient();

			try
			{
				await smtp.ConnectAsync(mailSettings.Host, mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
				await smtp.AuthenticateAsync(mailSettings.Mail,mailSettings.Password);
				await smtp.SendAsync(email);
				
			}
			catch (System.Exception e)
			{
				System.IO.Directory.CreateDirectory("mailLogs");
				var emailsavefile = string.Format(@"mailLogs/{0}.eml", Guid.NewGuid());
				await email.WriteToAsync(emailsavefile);

				logger.LogInformation("Lỗi gửi mail, lưu tại - "+ emailsavefile);
				logger.LogError(e.Message);
				Console.WriteLine(e.Message);
				return "Gửi thất bại";
			}
			smtp.Disconnect(true);	
			logger.LogInformation("send mail to " + mailContent.To + "--- thoi gian" + DateTime.Now.ToShortTimeString());
			return "Gui thanh cong"	;
		}
		public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
      await SendMail(new MailContent() {
            To = email,
            Subject = subject,
            Body = htmlMessage
      });
    }

  }
	public class MailContent 
	{
		public string To {set;get;}
		public string Subject {set;get;}
		public string Body {set;get;}
	}
}

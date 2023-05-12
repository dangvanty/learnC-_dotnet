using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_6_MailSend.Services
{
	public interface ISendMailService
	{
		Task<string> SendMail(MailContent mailContent);
    
    Task SendEmailAsync(string email, string subject, string htmlMessage);	
	}
}
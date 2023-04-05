using System;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
namespace asp07.Service
{
    public class SendMailService
    {
        MailSettings _mailSettings {set;get;}

        public SendMailService(IOptions<MailSettings> mailSettings){
            _mailSettings = mailSettings.Value;
        }
        public async Task<string> SendMail(MailContent mailContent){

            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName,_mailSettings.Mail);
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName,_mailSettings.Mail));

            email.To.Add(new MailboxAddress(mailContent.To,mailContent.To));
            email.Subject = mailContent.Subject;
          
            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try {
                await smtp.ConnectAsync(_mailSettings.Host, Convert.ToInt32(_mailSettings.Port), SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                
            }
            catch (Exception ex) {
                // Gửi mail thất bại
                
                return $"co loi xay ra {ex.Message}";
            }
            smtp.Disconnect(true);
            return "gui thanh cong";

        }
    }
    public class MailContent {
        public string To { get; set; }              // Địa chỉ gửi đến
        public string Subject { get; set; }         // Chủ đề (tiêu đề email)
        public string Body { get; set; }            // Nội dung (hỗ trợ HTML) của email
    }
}
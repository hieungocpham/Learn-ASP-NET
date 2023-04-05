using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MailUtils {
    public class MailUtils {
        public static async Task<string>  SendMail(string _from,string _to,string _subject,string _body){
            MailMessage message = new MailMessage(_from,_to,_subject,_body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);
            
            using var smtpClient = new SmtpClient("localhost");
            try {
                await smtpClient.SendMailAsync(message);
                return "gui mail thanh cong";
            }
            catch (System.Exception e){
                Console.WriteLine(e);
                return "gui mail that bai";
            }
            
        }
        public static async Task<string>  SendGmail(string _from,string _to,string _subject,string _body,string _gmail,string _password){
            MailMessage message = new MailMessage(_from,_to,_subject,_body);
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            message.ReplyToList.Add(new MailAddress(_from));
            message.Sender = new MailAddress(_from);
            
            using var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials =  new System.Net.NetworkCredential(_gmail,_password);
            try {
                await smtpClient.SendMailAsync(message);
                return "gui mail thanh cong";
            }
            catch (System.Exception e){
                Console.WriteLine(e);
                return $"gui mail that bai {e.Message}";
            }
            
        }
    }
}
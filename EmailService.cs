using System.Net;
using System.Net.Mail;

namespace crud;

public class EmailService
{
    private readonly string _from = "amiralisarvmeili@gmail.com";
    private readonly string _password = "bbyktxfpvujbhfor";
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var mail = new MailMessage();
        mail.From = new MailAddress(_from);
        mail.To.Add(to);
        mail.Subject = subject;
        mail.Body = body;
        using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
        {
            smtpClient.Credentials = new NetworkCredential(_from, _password);
            smtpClient.EnableSsl = true;
            await smtpClient.SendMailAsync(mail);
        }
    }  
}
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace CursoMod165.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Credentials = new NetworkCredential("cursoMOD165DiogoSilva@gmail.com", "djrwpbxmhurvsgug"),
                Port = 587,
                EnableSsl = true,
            };


            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress("cursoMOD165DiogoSilva@gmail.com", "Seguro Saúde Municipal"),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            mailMessage.Bcc.Add("cursoMOD165DiogoSilva@gmail.com");

            smtpClient.Send(mailMessage);

            return Task.CompletedTask;
        }
    }
}

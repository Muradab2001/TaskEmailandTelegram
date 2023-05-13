using MimeKit;
using Scheduling_reminders_via_email_or_Telegram.Models;
namespace Scheduling_reminders_via_email_or_Telegram.Services
{
    public class EmailService
    {
        public void SendEmail(Reminder reminder)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender Name", "muradama@code.edu.az"));
            message.To.Add(new MailboxAddress("murad", reminder.To));
            message.Subject = "Test email";

            message.Body = new TextPart("plain")
            {
                Text = reminder.Content
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("muradama@code.edu.az", "Password");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}

using Scheduling_reminders_via_email_or_Telegram.Models;
using System.Net;
using System.Text;

namespace Scheduling_reminders_via_email_or_Telegram.Services
{
    public class TelegramService
    {
        public void SendTelegram(Reminder reminder)
        {
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            string apiToken = "my_bot_api_token";
            string chatId = reminder.To;
            string text = reminder.Content;
            urlString = String.Format(urlString, apiToken, chatId, text);
            WebRequest request = WebRequest.Create(urlString);
            Stream rs = request.GetResponse().GetResponseStream();
            StreamReader reader = new StreamReader(rs);
            string line = "";
            StringBuilder sb = new StringBuilder();
            while (line != null)
            {
                line = reader.ReadLine();
                if (line != null)
                    sb.Append(line);
            }
            string response = sb.ToString();
        }
    }
}

using Hangfire;
using MailKit.Net.Smtp;
using Microsoft.Data.SqlClient;
using MimeKit;
using Scheduling_reminders_via_email_or_Telegram.Models;
using System.Net;
using System.Text;

namespace Scheduling_reminders_via_email_or_Telegram.Services
{
    public class ReminderService
    {
        public string ScheduleReminder(Reminder reminder)
        {
            EnumGetValueService getValueService = new EnumGetValueService();
            EmailService emailService = new EmailService();
            TelegramService telegramService = new TelegramService();
            int index = getValueService.EnumValue(reminder.MethodEnum);
            if (index==1)
            {
                return BackgroundJob.Schedule(() =>  emailService.SendEmail(reminder), reminder.SendAt);
            }
             return BackgroundJob.Schedule(() => telegramService.SendTelegram(reminder), reminder.SendAt);
        }
        public void DeleteReminder(string JobId)
        {
            BackgroundJob.Delete(JobId);
        }
    }
}

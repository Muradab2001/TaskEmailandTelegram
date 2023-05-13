using Scheduling_reminders_via_email_or_Telegram.Enums;

namespace Scheduling_reminders_via_email_or_Telegram.DTOs.Reminder
{
    public class ReminderPostDto
    {
        public string To { get; set; }
        public string Content { get; set; }
        public Enum_Method MethodEnum { get; set; }
        public DateTime SendAt { get; set; }
    }
}

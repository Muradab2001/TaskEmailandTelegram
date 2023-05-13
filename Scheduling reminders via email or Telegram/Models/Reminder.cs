using Scheduling_reminders_via_email_or_Telegram.Enums;
using Scheduling_reminders_via_email_or_Telegram.Models.Base;

namespace Scheduling_reminders_via_email_or_Telegram.Models
{
    public class Reminder:BaseEntity
    {
        public string Jobid { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public Enum_Method MethodEnum { get; set; }
    }
}

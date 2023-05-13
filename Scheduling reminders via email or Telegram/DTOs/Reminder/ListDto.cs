namespace Scheduling_reminders_via_email_or_Telegram.DTOs.Reminder
{
    public class ListDto<T>
    {
        public List<T> ListDtos { get; set; }
        public int TotalCount { get; set; }
    }
}

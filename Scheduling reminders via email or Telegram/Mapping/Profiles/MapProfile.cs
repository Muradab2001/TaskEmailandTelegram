using AutoMapper;
using Scheduling_reminders_via_email_or_Telegram.DTOs.Reminder;
using Scheduling_reminders_via_email_or_Telegram.Models;

namespace Scheduling_reminders_via_email_or_Telegram.Mapping.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Reminder,ReminderGetDto>();
            CreateMap<Reminder,ReminderListItemDto>();
        }
    }
}

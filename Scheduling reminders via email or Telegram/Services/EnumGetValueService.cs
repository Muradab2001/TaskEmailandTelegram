using Scheduling_reminders_via_email_or_Telegram.Enums;
using Scheduling_reminders_via_email_or_Telegram.Models;
using System;

namespace Scheduling_reminders_via_email_or_Telegram.Services
{
    public class EnumGetValueService
    {

        public int EnumValue(Enum_Method method)
        {
            int enumValue = (int)method;
            return enumValue;
        }
    }
}

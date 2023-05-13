using Microsoft.EntityFrameworkCore;
using Scheduling_reminders_via_email_or_Telegram.Models;

namespace Scheduling_reminders_via_email_or_Telegram.DAL
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> opt) : base(opt)
        {

        }
        public DbSet<Reminder> Reminders { get; set; }
    }
}

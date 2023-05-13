using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scheduling_reminders_via_email_or_Telegram.Models.Configurations
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.Property(rem=>rem.Content).HasMaxLength(100).IsRequired();
            builder.Property(rem => rem.To).HasMaxLength(50).IsRequired();
            builder.Property(rem => rem.SendAt).IsRequired();
            builder.Property(rem => rem.MethodEnum).IsRequired();
        }
    }
}

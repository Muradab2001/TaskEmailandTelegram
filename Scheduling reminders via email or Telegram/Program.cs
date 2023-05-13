using AspNetCoreRateLimit;
using FluentValidation.AspNetCore;
using Hangfire;
using Scheduling_reminders_via_email_or_Telegram;
using Scheduling_reminders_via_email_or_Telegram.DTOs.Reminder;
using Scheduling_reminders_via_email_or_Telegram.Mapping.Profiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<ReminderPostDto>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(opt => {
    opt.AddProfile(new MapProfile());
});
builder.Services.AddInfrastructureDI(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseAuthorization();
app.UseHangfireServer();
app.UseHangfireDashboard();
app.MapHangfireDashboard();
app.MapControllers();
app.Run();
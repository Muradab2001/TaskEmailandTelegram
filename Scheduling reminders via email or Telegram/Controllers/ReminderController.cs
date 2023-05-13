using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scheduling_reminders_via_email_or_Telegram.DAL;
using Scheduling_reminders_via_email_or_Telegram.DTOs.Reminder;
using Scheduling_reminders_via_email_or_Telegram.Models;
using Scheduling_reminders_via_email_or_Telegram.Services;

namespace Scheduling_reminders_via_email_or_Telegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly APIDbContext _context;
        private IMapper _mapper;


        public ReminderController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0) return BadRequest();
            Reminder reminder=_context.Reminders.FirstOrDefault(rem => rem.Id == id);
            if(reminder == null) return NotFound();
            ReminderGetDto dto =_mapper.Map<ReminderGetDto>(reminder);
            if(dto == null) return NotFound();
            return Ok(dto);
        }
        [HttpPut("updata/{id}")]
        public IActionResult Updata(int id, ReminderPostDto reminderPostDto)
        {
            if (id == 0) return BadRequest();
            if (reminderPostDto.SendAt < DateTime.Now) return BadRequest();
            Reminder existed = _context.Reminders.FirstOrDefault(rem => rem.Id == id);
            if (existed is null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(reminderPostDto);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var reminders = _context.Reminders.ToList();
            if(reminders is null ) return NotFound();
            ListDto<ReminderListItemDto> dto = new ListDto<ReminderListItemDto>
            {
                ListDtos = _mapper.Map<List<ReminderListItemDto>>(reminders),
                TotalCount = reminders.Count()
            };
            return Ok(dto);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ReminderPostDto reminderPostDto)
        {
            if (reminderPostDto is null || reminderPostDto.SendAt < DateTime.Now)
            {
                return BadRequest();
            }
            ReminderService reminderServie=new ReminderService();
            Reminder reminder = new Reminder
            {
                Content = reminderPostDto.Content,
                MethodEnum = reminderPostDto.MethodEnum,
                To= reminderPostDto.To,
                SendAt = reminderPostDto.SendAt
            };
            string Jobid = reminderServie.ScheduleReminder(reminder);
            reminder.Jobid = Jobid;
            await _context.Reminders.AddAsync(reminder);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { id = reminder.Id, Book = reminderPostDto });
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            Reminder existed = _context.Reminders.FirstOrDefault(rem => rem.Id == id);
            if (existed is null) return NotFound();
            ReminderService reminderServie = new ReminderService();
            reminderServie.DeleteReminder(existed.Jobid);
            _context.Remove(existed);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

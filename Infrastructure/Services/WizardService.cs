using AutoMapper;
using Core.Entities;
using Infrastructure.Data;
using Infrastructure.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class WizardService : IWizardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public WizardService(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<MessageDto> GetAsync(int id)
        {
            var message = await _context.Messages.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Message, MessageDto>(message);
        }

        public IEnumerable<MessageDto> GetAllAsync()
        {
            var messages = _context.Messages.ToList();
            return _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDto>>(messages);
        }

        public int Add(MessageDto m)
        {
            Console.WriteLine($" - AddAsync m {m.FirstName} {m.LastName} {m.EmailTo} {m.EmailCc} {m.TopicId} {m.MessageText}");
            var message = _mapper.Map<MessageDto, Message>(m);
            var _emailConfigSettings = _configuration.GetSection("EmailConfig").Get<EmailConfigSettings>();

            message.EmailCc = _emailConfigSettings.SmtpMessageTo;
            message.SendDateTime = DateTime.UtcNow;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return message.Id;
        }
    }
}

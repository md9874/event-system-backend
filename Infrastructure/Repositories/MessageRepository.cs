using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatContext _context;

        public MessageRepository(ChatContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages;
        }

        public Message GetById(int id)
        {
            return _context.Messages
                .Include(m => m.Conversation)
                .SingleOrDefault(x => x.Id == id);
        }

        public Message Add(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();

            return message;
        }
    }
}

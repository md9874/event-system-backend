using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly ChatContext _context;

        public ConversationRepository(ChatContext context)
        {
            _context = context;
        }

        public IEnumerable<Conversation> GetAll()
        {
            return _context.Conversations;
        }

        public Conversation GetById(int id)
        {
            return _context.Conversations
                .Include(x => x.Users)
                .SingleOrDefault(x => x.Id == id);
        }

        public Conversation Add(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
            _context.SaveChanges();

            return conversation;
        }

        public void Update(Conversation conversation)
        {
            conversation.LastModified = DateTime.UtcNow;
            _context.Conversations.Update(conversation);
            _context.SaveChanges();
        }

        public void Delete(Conversation conversation)
        {
            _context.Conversations.Remove(conversation);
            _context.SaveChanges();
        }
    }
}

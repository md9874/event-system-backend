using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IConversationRepository
    {
        IEnumerable<Conversation> GetAll();
        Conversation GetById(int id);
        Conversation Add(Conversation conversation);
        void Update(Conversation conversation);
        void Delete(Conversation conversation);
    }
}

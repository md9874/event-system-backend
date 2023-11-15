using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAll();
        Message GetById(int id);
        Message Add(Message message);
    }
}

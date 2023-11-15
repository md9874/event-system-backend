using Application.DTO.MessageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<MessageDTO> GetConversationMessages(int conversationId);
        MessageDTO AddNewMessage(CreateMessageDTO newMessage);
    }
}

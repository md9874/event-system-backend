using Application.DTO.ConversationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IConversationService
    {
        IEnumerable<ConversationDTO> GetAllUserConversations();
        ConversationDetailsDTO GetUserConversation(int id);
        ConversationDetailsDTO AddNewUserConversation(CreateConversationDTO newConversation);
        void ChangeUserConversationTitle(UpdateConversationDTO updatedConversation);
        void DeleteUserConversation(int id);
    }
}

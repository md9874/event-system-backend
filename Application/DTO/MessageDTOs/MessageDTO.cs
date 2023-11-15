using Application.DTO.ConversationDTOs;
using Application.DTO.UserDTOs;

namespace Application.DTO.MessageDTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserDTO User { get; set; }
        public ConversationDTO Conversation { get; set; }
    }
}

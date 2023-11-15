using Application.DTO.MessageDTOs;
using Application.DTO.UserDTOs;

namespace Application.DTO.ConversationDTOs
{
    public class ConversationDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<MessageDTO>? Messages { get; set; }
    }
}

using Application.DTO.ConversationDTOs;

namespace Application.DTO.UserDTOs
{
    public class UserDetailsDTO
    {
        public int Id { get; set; }
        public string Nick { get; set; }

        public List<ConversationDTO>? Conversations { get; set; }
    }
}

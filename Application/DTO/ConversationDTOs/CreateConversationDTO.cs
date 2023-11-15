namespace Application.DTO.ConversationDTOs
{
    public class CreateConversationDTO
    {
        public string Title { get; set; }
        public List<int> UserIds { get; set; }
    }
}

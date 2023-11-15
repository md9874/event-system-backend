namespace Application.DTO.MessageDTOs
{
    public class CreateMessageDTO
    {
        public string Content { get; set; }
        public int ConversationId { get; set; }
        public int UserId { get; set; }
    }
}

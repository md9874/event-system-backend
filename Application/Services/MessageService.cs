using Application.DTO.ConversationDTOs;
using Application.DTO.MessageDTOs;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConversationRepository _conversationRepository;
        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IConversationRepository conversationRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _conversationRepository = conversationRepository;
        }

        public IEnumerable<MessageDTO> GetConversationMessages(int conversationId)
        {
            var messages = _messageRepository.GetAll().Where(m => m.ConversationId == conversationId);
            return messages.Select(x =>
                new MessageDTO()
                {
                    Id = x.Id,
                    Content = x.Content,
                }
            );
        }
        public MessageDTO AddNewMessage(CreateMessageDTO newMessage)
        {
            if (string.IsNullOrEmpty(newMessage.Content))
            {
                throw new Exception("Message can not have an empty content.");
            }

            Message message = new Message()
            {
                Content = newMessage.Content,
                Conversation = _conversationRepository.GetById(newMessage.ConversationId),
                User = _userRepository.GetById(newMessage.UserId)
            };

            message = _messageRepository.Add(message);

            return new MessageDTO()
            {
                Id = message.Id,
                Content = message.Content,
                Conversation = new ConversationDTO()
                {
                    Id = message.Conversation.Id,
                    Title = message.Conversation.Title
                },
                User = new UserDTO()
                {
                    Id = message.User.Id,
                    Nick = message.User.Nick
                }
            };
        }
    }
}

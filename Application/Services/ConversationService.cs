using Application.DTO.ConversationDTOs;
using Application.DTO.MessageDTOs;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;
        public ConversationService(IConversationRepository conversationRepository, IUserRepository userRepository)
        {
            _conversationRepository = conversationRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<ConversationDTO> GetAllUserConversations()
        {
            var conversations = _conversationRepository.GetAll();
            return conversations.Select(x =>
            new ConversationDTO()
            {
                Id = x.Id,
                Title = x.Title
            });
        }

        public ConversationDetailsDTO GetUserConversation(int id)
        {
            var conversation = _conversationRepository.GetById(id);

            ConversationDetailsDTO foundConversation = new ConversationDetailsDTO()
            {
                Id = conversation.Id,
                Title = conversation.Title,
            };

            if (conversation.Users != null)
            {
                foundConversation.Users = conversation.Users.Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Nick = x.Nick
                }).ToList();
            }

            if (conversation.Messages != null)
            {
                foundConversation.Messages = conversation.Messages.Select(x =>
                    new MessageDTO()
                    {
                        Id = x.Id,
                        Content = x.Content,
                    }
                ).ToList();
            }

            return foundConversation;
        }

        public ConversationDetailsDTO AddNewUserConversation(CreateConversationDTO newConversation)
        {
            var users = _userRepository.GetAll().Where(u => newConversation.UserIds.Exists(id => u.Id == id)).ToList();
            
            Conversation conversation = new Conversation()
            {
                Title = newConversation.Title,
                Users = users
            };

            _conversationRepository.Add(conversation);

            ConversationDetailsDTO existingConversation = new ConversationDetailsDTO()
            {
                Id = conversation.Id,
                Title = conversation.Title,
            };

            if (conversation.Users != null)
            {
                existingConversation.Users = conversation.Users.Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Nick = x.Nick
                }).ToList();
            }

            if (conversation.Messages != null)
            {
                existingConversation.Messages = conversation.Messages.Select(x =>
                    new MessageDTO()
                    {
                        Id = x.Id,
                        Content = x.Content,
                    }
                ).ToList();
            }

            return existingConversation;
        }

        public void ChangeUserConversationTitle(UpdateConversationDTO updatedConversation)
        {
            var existingConversation = _conversationRepository.GetById(updatedConversation.Id);

            existingConversation.Title = updatedConversation.Title;

            _conversationRepository.Update(existingConversation);
        }

        public void DeleteUserConversation(int id)
        {
            var conversation = _conversationRepository.GetById(id);
            _conversationRepository.Delete(conversation);
        }
    }
}

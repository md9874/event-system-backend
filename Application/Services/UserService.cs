using Application.DTO.ConversationDTOs;
using Application.DTO.UserDTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userRepository.GetAll();

            return users.Select(x => 
            new UserDTO() { 
                Id = x.Id, 
                Nick = x.Nick 
            });
        }

        public UserDetailsDTO GetUserDetails(int id)
        {
            var user = _userRepository.GetById(id);

            UserDetailsDTO foundUser = new UserDetailsDTO()
            {
                Id = user.Id,
                Nick = user.Nick
            };

            if (user.Conversations != null)
            {
                foundUser.Conversations = user.Conversations.Select(x => new ConversationDTO()
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
            }

            return foundUser;
        }
        public UserDetailsDTO AddNewUser(CreateUserDTO newUser)
        {
            if (string.IsNullOrEmpty(newUser.Nick))
            {
                throw new Exception("User can not have an empty nick.");
            }
            if (string.IsNullOrEmpty(newUser.Password))
            {
                throw new Exception("User can not have an empty password.");
            }

            User user = new User() {
                Nick = newUser.Nick,
                Password = newUser.Password
            };
            user = _userRepository.Add(user);

            UserDetailsDTO createdUser = new UserDetailsDTO()
            {
                Id = user.Id,
                Nick = user.Nick
            };

            if (user.Conversations != null)
            {
                createdUser.Conversations = user.Conversations.Select(x => new ConversationDTO()
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
            }

            return createdUser;
        }

        public void ChangePassword(ChangeUserPasswordDTO updatedUser)
        {
            var existingUser = _userRepository.GetById(updatedUser.Id);

            existingUser.Password = updatedUser.Password;

            _userRepository.Update(existingUser);
        }
    }
}

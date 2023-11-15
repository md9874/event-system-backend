using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}

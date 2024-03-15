using MyWebAPI.Models;

namespace MyWebAPI.Repository
{
    public interface IUserRepository
    {
        Task<int> CreateUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
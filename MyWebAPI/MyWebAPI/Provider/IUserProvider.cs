using MyWebAPI.Models;

namespace MyWebAPI.Provider
{
    public interface IUserProvider
    {
        Task<int> RegisterUserAsync(User user);
        Task<string> AuthenticateUserAsync(string email, string password);
    }
}
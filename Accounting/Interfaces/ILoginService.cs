using Accounting.Models;

namespace Accounting.Interfaces
{
    public interface ILoginService
    {
        Task<UserLogin> GetUserAsync(string username);
        Task<List<UserLogin>> GetAllUserAsync();
        Task AddUserAsync(string username, string password);
        Task UpdatePasswordAsync(string username, string password);
        Task DeleteUserAsync(string username, string password);

    }
}

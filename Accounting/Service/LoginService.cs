using Accounting.Interfaces;
using Accounting.Models;
using Accounting.Specifications;

namespace Accounting.Service
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<UserLogin> _userLoginRepository;

        public LoginService(IRepository<UserLogin> userLoginRepository) 
        {
            _userLoginRepository = userLoginRepository;
        }

        public async Task<UserLogin> GetUserAsync(string username)
        {
            var getdata = new UserLoginSpecification(username);
            return  await _userLoginRepository.SingleOrDefaultAsync(getdata);
        }

        public async Task<List<UserLogin>> GetAllUserAsync()
        {
            return await _userLoginRepository.ListAsync();
        }

        public async Task AddUserAsync(string username, string password)
        {
            UserLogin data = new UserLogin()
            {
                Username = username,
                Password = password,
                CreatedDate = DateTime.Now,
                UpdateDate= DateTime.Now
            };
            await _userLoginRepository.AddAsync(data);
        }

        public async Task UpdatePasswordAsync(string username,string password)
        {
            var updateData = new UserLoginSpecification(username);
            var data = await _userLoginRepository.SingleOrDefaultAsync(updateData);
            if (data != null)
            {
                data.Password= password;
                data.UpdateDate = DateTime.Now;
                await _userLoginRepository.UpdateAsync(data);
            }
        }

        public async Task DeleteUserAsync(string username,string password)
        {
            var deleteData = new UserLoginSpecification(username);
            var data = await _userLoginRepository.SingleOrDefaultAsync(deleteData);
            await _userLoginRepository.DeleteAsync(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace PunkyBeer.Services
{
    public class UserService : IUserService
    {
        private const string UserName = nameof(UserName);

        private readonly ISecureStorage _secureStorage;

        public UserService(ISecureStorage secureStorage)
        {
            _secureStorage = secureStorage;
        }

        public async Task SetUserName(string userName)
        {
            await _secureStorage.SetAsync(UserName, userName);
        }

        public async Task<string> GetUserName()
        {
            return await _secureStorage.GetAsync(UserName);
        }
    }
}

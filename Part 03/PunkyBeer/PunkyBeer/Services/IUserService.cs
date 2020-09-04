using System.Threading.Tasks;

namespace PunkyBeer.Services
{
    public interface IUserService
    {
        Task<string> GetUserName();
        Task SetUserName(string userName);
    }
}
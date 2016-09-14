using aspnet_mvc5_mongodb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnet_mvc5_mongodb.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task InsertAsync(User document);
        Task<bool> UpdateAsync(User document);
        Task DeleteAsync(string id);
    }
}

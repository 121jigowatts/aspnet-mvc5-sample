using aspnet_mvc5_mongodb.Models;
using aspnet_mvc5_mongodb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_mongodb.Services.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task InsertAsync(User document);
        Task<bool> UpdateAsync(User document);
        Task DeleteAsync(string id);
        Task<UserSearchViewModel> SearchAsync(UserSearchCondition condition);
    }
}

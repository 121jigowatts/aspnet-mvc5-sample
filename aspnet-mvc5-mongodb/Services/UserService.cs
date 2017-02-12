using aspnet_mvc5_mongodb.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspnet_mvc5_mongodb.ViewModels;
using System.Threading.Tasks;
using aspnet_mvc5_mongodb.Repositories.Abstractions;
using aspnet_mvc5_mongodb.Repositories;
using aspnet_mvc5_mongodb.Models;

namespace aspnet_mvc5_mongodb.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        #region Constructors
        public UserService()
            : this(new UserRepository())
        {

        }

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        #endregion
        

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(User document)
        {
            await _repository.InsertAsync(document);
        }

        public async Task<bool> UpdateAsync(User document)
        {
            return await _repository.UpdateAsync(document);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<UserSearchViewModel> SearchAsync(UserSearchCondition condition)
        {
            var model = new UserSearchViewModel();
            model.users = await _repository.SearchAsync(condition);
            model.userSearchCondition = condition;

            return model;
        }

    }
}
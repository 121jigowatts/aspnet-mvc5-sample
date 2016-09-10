﻿using aspnet_mvc5_mongodb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_mongodb.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task InsertAsync(User document);
        Task UpdateAsync(User document);
        Task DeleteAsync(string id);
    }
}
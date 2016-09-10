using aspnet_mvc5_mongodb.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using aspnet_mvc5_mongodb.Models;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace aspnet_mvc5_mongodb.Repositories
{
    public class UserRepository : MongoDB, IUserRepository
    {
        private static readonly string Collection = "users";


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var collection = GetCollection<User>(Collection);
            var filter = new BsonDocument();
            var result = await collection.Find(filter).ToListAsync();

            return result;
        }

        public Task<User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(User document)
        {
            var collection = GetCollection<User>(Collection);
            await collection.InsertOneAsync(document);
        }

        public Task UpdateAsync(User document)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
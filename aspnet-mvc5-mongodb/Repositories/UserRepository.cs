using aspnet_mvc5_mongodb.Models;
using aspnet_mvc5_mongodb.Repositories.Abstractions;
using aspnet_mvc5_mongodb.ViewModels;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_mvc5_mongodb.Repositories
{
    public class UserRepository : MongoDB, IUserRepository
    {
        private static readonly string Collection = "users";


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var collection = GetCollection<User>(Collection);
            //var filter = new BsonDocument();
            //var result = await collection.Find(filter).ToListAsync();

            //return result;
            return await collection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var collection = GetCollection<User>(Collection);
            //var objId = ObjectId.Parse(id);
            //var filter = Builders<User>.Filter.Eq("_id", objId);
            //return await collection.Find(filter).FirstOrDefaultAsync();

            return await collection.Find(d => d.Id == id).FirstOrDefaultAsync();

        }

        public async Task InsertAsync(User document)
        {
            document.Revision = 1;
            document.LastModified = DateTime.Now;
            var collection = GetCollection<User>(Collection);
            await collection.InsertOneAsync(document);
        }

        public async Task<bool> UpdateAsync(User document)
        {
            var collection = GetCollection<User>(Collection);
            //var objId = ObjectId.Parse(document.Id);
            //var filter = Builders<User>.Filter.Eq("_id", objId);
            //var update = Builders<User>.Update
            //    .Set("name", document.Name)
            //    .Set("age", document.Age)
            //    .Set("email", document.Email)
            //    .Set("address", document.Address);

            //await collection.UpdateOneAsync(filter, update);

            var builder = Builders<User>.Filter;
            var filter = builder.Eq(d => d.Id, document.Id)
                & builder.Eq(d => d.Revision, document.Revision);

            var update = Builders<User>.Update
                .Set(d => d.Name, document.Name)
                .Set(d => d.Age, document.Age)
                .Set(d => d.Email, document.Email)
                .Set(d => d.Address, document.Address)
                .CurrentDate(d => d.LastModified)
                .Inc(d => d.Revision, 1);

            var result = await collection.UpdateOneAsync(filter, update);
            if (result.IsModifiedCountAvailable && result.ModifiedCount == 1)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteAsync(string id)
        {
            var collection = GetCollection<User>(Collection);
            //var objId = ObjectId.Parse(id);
            //var filter = Builders<User>.Filter.Eq("_id", objId);
            //await collection.DeleteOneAsync(filter);

            await collection.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<User>> SearchAsync(UserSearchCondition condition)
        {
            var collection = GetCollection<User>(Collection);
            IMongoQueryable<User> query = collection.AsQueryable<User>();
            if (condition.userName != null)
            {
                query = query.Where(x => x.Name.Contains(condition.userName));
            }

            if (condition.fromUserAge != null)
            {
                var fromUserAge = int.Parse(condition.fromUserAge);
                query = query.Where(x => x.Age >= fromUserAge);
            }

            if (condition.toUserAge != null)
            {
                var toUserAge = int.Parse(condition.toUserAge);
                query = query.Where(x => x.Age <= toUserAge);
            }

            if (condition.userEmail != null)
            {
                query = query.Where(x => x.Email.Contains(condition.userEmail));
            }

            if (condition.userAddress != null)
            {
                query = query.Where(x => x.Address.Contains(condition.userAddress));
            }

            return await query.ToListAsync();
        }
    }
}
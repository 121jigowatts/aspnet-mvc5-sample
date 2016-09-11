using MongoDB.Driver;
using System.Configuration;

namespace aspnet_mvc5_mongodb.Repositories
{
    public class MongoDB
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoDB()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnection"];
            var database = ConfigurationManager.AppSettings["Database"];
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(database);
        }

        public static IMongoCollection<T> GetCollection<T>(string collection)
        {
            return _database.GetCollection<T>(collection);
        }

    }
}
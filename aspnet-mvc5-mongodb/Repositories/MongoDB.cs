using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace aspnet_mvc5_mongodb.Repositories
{
    public class MongoDB
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoDB()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDBConnection"];
            _client = new MongoClient(connectionString);
            var database = ConfigurationManager.AppSettings["Database"];
            _database = _client.GetDatabase(database);
        }

        public static IMongoCollection<T> GetCollection<T>(string collection)
        {
            return _database.GetCollection<T>(collection);
        }

    }
}
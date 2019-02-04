using System;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Backend.Models;

namespace Backend.DatabaseContext
{
    public class UserContext : DbContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase _database;

        public UserContext(IConfiguration config)
        {
             client = new MongoClient(config.GetConnectionString("mongodb://localhost:27017"));
             _database = client.GetDatabase("UserDb");

        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("Users");
            }
        }

    }
}
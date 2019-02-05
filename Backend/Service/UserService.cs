using System;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using Backend.Models;

namespace Backend.Service
{
    public class UserService {
        private readonly MongoClient client;
        private readonly IMongoCollection<User> _users;
        public UserService(IConfiguration config){
            client = new MongoClient(config.GetConnectionString("DatabaseConnection"));
            var database = client.GetDatabase("UserDb");
            _users = database.GetCollection<User>("Users");
        }
        public async Task<List<User>> GetUserList()
        {
           var filter = Builders<User>.Filter.Empty;
           var userList = await _users.Find(filter).ToListAsync();
           return userList;
        }
    }
}
using System;
using System.Linq;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using Backend.Models;
using Backend.DatabaseContext;

namespace Backend.Service
{
    public class UserService {
    //private readonly MongoClient client;
    //private readonly IMongoCollection<User> _users;

        private readonly UserContext _context;

        public UserService(IConfiguration config, UserContext context){
            // client = new MongoClient(config.GetConnectionString("DatabaseConnection"));
            // var database = client.GetDatabase("UserDb");
            // var _users = database.GetCollection<User>("Users");

            _context = context;
        }

        public async Task<List<User>> GetUserList()
        {
           var filter = Builders<User>.Filter.Empty;
           var userList = await _context.Users.Find(filter).ToListAsync();
           return userList;
        }
    }
}
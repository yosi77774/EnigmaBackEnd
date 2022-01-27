using EnigmaServer1.models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnigmaServer1.Services
{
    public class UserService
    {
        public Boolean V = false;
        private readonly IMongoCollection<User> _Users;

        public UserService(IUserSettings settings)
        {
            var cliente = new MongoClient(settings.ConnectionString);
            var db = cliente.GetDatabase("dbUsers");
            _Users = db.GetCollection<User>("users");
        }

        public UserService()
        {
        }

     
        public async Task<List<User>> GetAsync()
        {
            List<User> users1 = await _Users.Find(u => true).ToListAsync();
            return users1;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            var user = await _Users.FindAsync(user => user._id == id);

            return await user.FirstOrDefaultAsync();
        }

        public async Task<String> CreateUserAsync(User user)
        {
            List<User> users1 = await _Users.Find(u => true).ToListAsync();
            foreach (User user1 in users1)
            {
                if (user.Password == user1.Password)
                {
                    return "Choose a different password";
                }

            }
            await _Users.InsertOneAsync(user);
            return "Registration completed";
        }

        public async Task UpdateAsync(string id, User user)
        {
            await _Users.ReplaceOneAsync(us => us._id == id, user);
        }

        public async Task DeleteAsync(User user)
        {
            await _Users.DeleteOneAsync(user1 => user1._id == user._id);
        }

        public async Task DeleteByIdAsync(string id)
        {
            await _Users.DeleteOneAsync(user1 => user1._id == id);
        }

        public async Task<Boolean> GetByUserPasswordAsync(string userName, string password)
        {
            V = false;
            List<User> users1 = await _Users.Find(u => true).ToListAsync();
            foreach(User user1 in users1)
            {
                if (userName == user1.UserName && password == user1.Password)
                {
                     V = true;
                    return V;
                }

            }
             return V;
        }
    }
}

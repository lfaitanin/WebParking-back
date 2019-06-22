using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using Parkingspot.Models;

namespace UserApp.Models
{

    public class UserRepository : IUserRepository
    {
        private readonly IUserContext _context;

        public UserRepository(IUserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context
                            .Users
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<User> GetUser(long id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.Id, id);
            return _context
                    .Users
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }

        public async Task Create(User User)
        {
            await _context.Users.InsertOneAsync(User);
        }
        public async Task<bool> Update(User User)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Users
                        .ReplaceOneAsync(
                            filter: g => g.Id == User.Id,
                            replacement: User);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Users
                                                .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<long> GetNextId()
        {
            return await _context.Users.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}
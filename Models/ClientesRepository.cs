using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Models
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly IClientesContext _context;
        public ClientesRepository(IClientesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Clientes>> GetAllCliente()
        {
            return await _context
                            .Cliente
                            .Find(_ => true)
                            .ToListAsync();
        }
        public Task<Clientes> GetCliente(long id)
        {
            FilterDefinition<Clientes> filter = Builders<Clientes>.Filter.Eq(m => m.Id, id);
            return _context
                    .Cliente
                    .Find(filter)
                    .FirstOrDefaultAsync();
        }
        public async Task Create(Clientes user)
        {
            await _context.Cliente.InsertOneAsync(user);
        }
        public async Task<bool> Update(Clientes user)
        {
            ReplaceOneResult updateResult =
                await _context
                        .Cliente
                        .ReplaceOneAsync(
                            filter: g => g.Id == user.Id,
                            replacement: user);
            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> Delete(long id)
        {
            FilterDefinition<Clientes> filter = Builders<Clientes>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _context
                                                .Cliente
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
        public async Task<long> GetNextId()
        {
            return await _context.Cliente.CountDocumentsAsync(new BsonDocument()) + 1;
        }
    }
}

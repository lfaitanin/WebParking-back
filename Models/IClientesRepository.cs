using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Models
{
    public interface IClientesRepository
    {
        // api/[GET]
        Task<IEnumerable<Clientes>> GetAllCliente();
        // api/1/[GET]
        Task<Clientes> GetCliente(long id);
        // api/[POST]
        Task Create(Clientes Cliente);
        // api/[PUT]
        Task<bool> Update(Clientes Cliente);
        // api/1/[DELETE]
        Task<bool> Delete(long id);
        Task<long> GetNextId();
    }
}

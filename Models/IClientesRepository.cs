using Parkingspot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Models
{

    public interface IClientesRepository
    {
        // api/[GET]
        Task<IEnumerable<Clientes>> GetAllClientes();

        // api/1/[GET]
        Task<Clientes> GetCliente(long id);

        // api/[POST]
        Task Create(Clientes User);

        // api/[PUT]
        Task<bool> Update(Clientes User);

        // api/1/[DELETE]
        Task<bool> Delete(long id);

        Task<long> GetNextId();
    }
}
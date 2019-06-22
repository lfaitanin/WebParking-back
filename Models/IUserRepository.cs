using Parkingspot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace UserApp.Models
{

    public interface IUserRepository
    {
        // api/[GET]
        Task<IEnumerable<User>> GetAllUsers();

        // api/1/[GET]
        Task<User> GetUser(long id);

        // api/[POST]
        Task Create(User User);

        // api/[PUT]
        Task<bool> Update(User User);

        // api/1/[DELETE]
        Task<bool> Delete(long id);

        Task<long> GetNextId();
    }
}
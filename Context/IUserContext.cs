using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Context
{
    public interface IUserContext
    {
        void AddUser(User user);
        List<User> GetAll();
    }
}

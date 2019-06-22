using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Parkingspot.Models
{
    public interface IClientesContext
    {
        IMongoCollection<Clientes> Cliente { get; }
    }

}

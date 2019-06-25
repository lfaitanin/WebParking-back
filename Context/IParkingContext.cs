using System.Collections.Generic;
using System.Threading.Tasks;
using Parkingspot.Models;

namespace Parkingspot.Context
{
    public interface IParkingContext
    {

        //IMongoCollection<Parking> Cliente { get; }
        T GetItem<T>(string codigo);
        Parking AddItem(Parking parking);
        R RemoveItem<R>(string id);
        List<Parking> GetAll();
    }

}

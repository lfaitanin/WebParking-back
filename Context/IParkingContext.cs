using Parkingspot.Models;

namespace Parkingspot.Context
{
    public interface IParkingContext
    {
        //IMongoCollection<Parking> Cliente { get; }
        T GetItem<T>(string codigo);
        Parking AddItem(Parking parking);
    }

}

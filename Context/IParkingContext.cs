using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Context
{
    public interface IParkingContext
    {
        Task<Parking> GetParking(string id);
        Parking AddItem(Parking parking);
        R RemoveItem<R>(string id);
        List<Parking> GetAll();
        void Update(string id, Parking parkingIn);

    }
}

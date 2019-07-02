using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Context
{
    public interface IParkingContext
    {
        T GetItem<T>(string codigo);
        Parking AddItem(Parking parking);
        R RemoveItem<R>(string codigo);
        List<Parking> GetAll();
    }
}

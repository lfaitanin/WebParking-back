using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.BLL
{
    public interface ILocationLogic
    {
        double[] GetCoordinates(string LocationId);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.BLL
{
    public interface ILocationLogic
    {
        string[] GetCoordinates(string LocationId);
    }
}

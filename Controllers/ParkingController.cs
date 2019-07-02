using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parkingspot.BLL;
using Parkingspot.Context;
using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parkingspot.Controllers
{
    [Route("api/[Controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ParkingContext _parkingContext;

        public ParkingController(ParkingContext parkingContext)
        {
            _parkingContext = parkingContext;
        }

        [HttpGet]
        public ActionResult<List<Parking>> Get()
        {
            return _parkingContext.Get();
        }

        [HttpGet("Code", Name = "GetParking")]
        public ActionResult<Parking> Get(string id)
        {
            var parking = _parkingContext.Get(id);
            if (parking == null)
            {
                return NotFound();
            }
            return parking;
        }

        [HttpPost]
        public ActionResult<Parking> Create(Parking parking)
        {
            return CreatedAtRoute("GetParking", new
            {
                id = parking.Code.ToString()
            }, parking);
        }

        [HttpPut("Code")]
        public IActionResult Update(string id, Parking newParking)
        {
            var parking = _parkingContext.Get(id);
            if(parking == null)
            {
                return NotFound();
            }
            _parkingContext.Update(id, newParking);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var parking = _parkingContext.Get(id);
            if (parking == null)
            {
                return NotFound();
            }
            _parkingContext.Remove(id);
            return NoContent();
        }
    }
}

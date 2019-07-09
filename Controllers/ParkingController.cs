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
        private readonly IParkingContext _context;
        private readonly ILocationLogic _locationLogic;

        public ParkingController(IParkingContext context, ILocationLogic locationLogic)
        {
            _context = context;
            _locationLogic = locationLogic;
        }

        [HttpGet("{id}")]
        public Task<Parking> Get(string id)
        {
            return _context.GetParking(id);
        }

        [HttpPost("add")]
        public IActionResult AddParking([FromBody] Parking parking)
        {
            if (!string.IsNullOrEmpty(parking.LocationId))
                parking.Coordinates = GetParkingCoordinates(parking.LocationId);

            var savedParking = _context.AddItem(parking);
            if (parking != null)
                return Ok(savedParking);
            else
                return NotFound("Erro ao inserir um novo estacionamento!");
        }

        private double[] GetParkingCoordinates(string locationId)
        {
            return _locationLogic.GetCoordinates(locationId);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveParking(string id)
        {
            var result = _context.RemoveItem(id);
            if (result)
                return Ok();
            else
                return NotFound("No pode ser deletado");
        }

        [HttpGet("all")]
        public IActionResult GetAllParkings()
        {
            var parking = _context.GetAll();
            if (parking.Count > 0)
                return Ok(parking);
            else
                return NotFound("Nao há dados para mostrar");
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]Parking parkingIn)
        {
            var park = _context.GetParking(id);
            if (park == null)
            {
                return NotFound();
            }
            _context.Update(id, parkingIn);
            return NoContent();
        }


    }
}

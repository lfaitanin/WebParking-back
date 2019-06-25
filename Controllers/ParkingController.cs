using Microsoft.AspNetCore.Mvc;
using Parkingspot.Context;
using Parkingspot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parkingspot.Controllers
{
    [Route("api/[Controller]")]
    public class ParkingController
    {
        private readonly IParkingContext _context;
        
        public ParkingController(IParkingContext context)
        {
            _context = context;
        }

        [HttpGet("{code}")]
        public IActionResult GetParking(string code)
        {
            Parking prod = _context.GetItem<Parking>(code);

            if (prod != null)
                return new ObjectResult(prod);
            else
                return new NotFoundObjectResult("Codigo nao encontrado!");
        }

        [HttpPost("add")]
        public IActionResult AddParking([FromBody] Parking parking)
        {
           var savedParking = _context.AddItem(parking);
            if (parking != null)
            {
                return new ObjectResult(savedParking);
            }
            else
                return new NotFoundObjectResult("Erro ao inserir um novo estacionamento!");
        }

        [HttpDelete("{code}")]
        public IActionResult RemoveParking(string code)
        {
            Parking prod = _context.RemoveItem<Parking>(code);
            if (prod != null)
                return new ObjectResult(prod);
            else
                return new NotFoundObjectResult("No pode ser deletado");
        }

        [HttpGet("all")]
        public IActionResult GetAllParkings()
        {
            var prod = _context.GetAll();
            if (prod.Count > 0)
                return new ObjectResult(prod);
            else
                return new NotFoundObjectResult("Nao há dados para mostrar");
        }


    }
}

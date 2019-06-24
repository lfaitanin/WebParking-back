﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("parking/{code}")]
        public IActionResult GetParking(string code)
        {
            Parking prod = _context.GetItem<Parking>(code);

            if (prod != null)
                return new ObjectResult(prod);
            else
                return new NotFoundObjectResult("Codigo nao encontrado!");
        }

        [HttpPost("parking/add")]
        public IActionResult AddParking([FromBody] Parking parking)
        {
            if (parking != null)
            {
                var savedParking = _context.AddItem(parking);
                return new ObjectResult(savedParking);
            }
            else
                return new NotFoundObjectResult("Erro ao inserir um novo estacionamento!");
        }

        [HttpDelete("parking/{code}")]
        public IActionResult RemoveParking(string code)
        {
            Parking prod = _context.RemoveItem<Parking>(code);
            if (prod != null)
                return new ObjectResult(prod);
            else
                return new NotFoundObjectResult("No pode ser deletado");
        }
        [HttpGet("parking/all")]
        private async Task<IEnumerable<Parking>> GetProductInternal()
        {
            return await _context.GetAllProducts();
        }
    }
}

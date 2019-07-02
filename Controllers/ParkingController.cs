﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{code}")]
        public IActionResult GetParking(string code)
        {
            Parking parking = _context.GetItem<Parking>(code);

            if (parking != null)
                return Ok(parking);
            else
                return NotFound("Codigo nao encontrado!");
        }

        [HttpPost("add")]
        public IActionResult AddParking([FromBody] Parking parking)
        {
            //if (!string.IsNullOrEmpty(parking.LocationId))
                //parking.Coordinates = GetParkingCoordinates(parking.LocationId);

            var savedParking = _context.AddItem(parking);
            if (parking != null)
                return Ok(savedParking);
            else
                return NotFound("Erro ao inserir um novo estacionamento!");
        }

        private string[] GetParkingCoordinates(string locationId)
        {
            return _locationLogic.GetCoordinates(locationId);
        }

        [HttpDelete("{code}")]
        public IActionResult RemoveParking(string code)
        {
            Parking parking = _context.RemoveItem<Parking>(code);
            if (parking != null)
                return Ok(parking);
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


    }
}

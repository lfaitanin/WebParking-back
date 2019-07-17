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
    public class UserController : ControllerBase
    {
        private readonly IUserContext _context;

        public UserController(IUserContext context)
        {
            _context = context;
        }

       [HttpPost("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                _context.AddUser(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            var users = _context.GetAll();
            if (users.Count > 0)
                return Ok(users);
            else
                return NotFound("Nao há dados para mostrar");
        }

    }
}

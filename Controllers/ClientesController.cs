using Microsoft.AspNetCore.Mvc;
using Models;
using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parkingspot.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ClientesController
    {
        private readonly IClientesRepository _repo;
        
        public ClientesController(IClientesRepository repo)
        {
            _repo = repo;
        }
        // GET api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {
            return new ObjectResult(await _repo.GetAllClientes());
        }
        // GET api/todos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> Get(long id)
        {
            var todo = await _repo.GetCliente(id);
            if (todo == null)
                return new NotFoundResult();

            return new ObjectResult(todo);
        }
        // POST api/todos
        [HttpPost]
        public async Task<ActionResult<Clientes>> Post([FromBody] Clientes clientes)
        {
            clientes = new Clientes
            {
                Adress = "asdad",
                Id = 1,
                Coordinates = 0.1
            };
            clientes.Id = await _repo.GetNextId();
            await _repo.Create(clientes);
            return new OkObjectResult(clientes);
        }
        // PUT api/todos/1
        [HttpPut("{id}")]
        public async Task<ActionResult<Clientes>> Put(long id, [FromBody] Clientes clientes)
        {
            var todoFromDb = await _repo.GetCliente(id);
            if (todoFromDb == null)
                return new NotFoundResult();
            clientes.Id = todoFromDb.Id;
            clientes.InternalId = todoFromDb.InternalId;
            await _repo.Update(clientes);
            return new OkObjectResult(clientes);
        }
        // DELETE api/todos/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetCliente(id);
            if (post == null)
                return new NotFoundResult();
            await _repo.Delete(id);
            return new OkResult();
        }
    }
}

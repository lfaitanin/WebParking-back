using Microsoft.AspNetCore.Mvc;
using Parkingspot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApp.Models;

namespace Parkingspot.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return new ObjectResult(await _repo.GetAllUsers());
        }

        // GET api/Users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(long id)
        {
            var User = await _repo.GetUser(id);

            if (User == null)
                return new NotFoundResult();

            return new ObjectResult(User);
        }

        // POST api/Users
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User User)
        {
            User.Id = await _repo.GetNextId();
            await _repo.Create(User);
            return new OkObjectResult(User);
        }

        // PUT api/Users/1
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(long id, [FromBody] User User)
        {
            var UserFromDb = await _repo.GetUser(id);

            if (UserFromDb == null)
                return new NotFoundResult();

            User.Id = UserFromDb.Id;
            User.InternalId = UserFromDb.InternalId;

            await _repo.Update(User);

            return new OkObjectResult(User);
        }

        // DELETE api/Users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _repo.GetUser(id);

            if (post == null)
                return new NotFoundResult();

            await _repo.Delete(id);

            return new OkResult();
        }
    }
}

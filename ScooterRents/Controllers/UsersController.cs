using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScooterRents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Users>>> Get()
        {

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found.");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Users>>> UpdateUser(Users request)
        {
            var dbuser = await _context.Users.FindAsync(request.Id);
            if (dbuser == null)
                return BadRequest("User not found."); 

            dbuser.Nickname = request.Nickname;
            dbuser.FirstName = request.FirstName;
            dbuser.LastName = request.LastName;
            dbuser.Place = request.Place;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Users>>> DeleteUser(int id)
        {
            var dbuser = await _context.Users.FindAsync(id);
            if (dbuser == null)
                return BadRequest("User not found.");

            _context.Users.Remove(dbuser);
            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }
    }
}

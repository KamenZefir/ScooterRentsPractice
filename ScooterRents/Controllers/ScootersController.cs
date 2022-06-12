using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScooterRents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScootersController : ControllerBase
    {
    

        private readonly DataContext _context;

        public ScootersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Scooters>>> Get()
        {

            return Ok(await _context.Scooters.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Scooters>> Get(int id)
        {
            var scooter = await _context.Scooters.FindAsync(id);
            if (scooter == null)
                return BadRequest("Scooter not found.");
            return Ok(scooter);
        }

        [HttpPost]
        public async Task<ActionResult<List<Scooters>>> AddScooter(Scooters scooter)
        {
            _context.Scooters.Add(scooter);
            await _context.SaveChangesAsync();

            return Ok(await _context.Scooters.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Scooters>>> UpdateScooter(Scooters request)
        {
            var dbscooters = await _context.Scooters.FindAsync(request.Id);
            if (dbscooters == null)
                return BadRequest("Scooter not found.");

            dbscooters.Model = request.Model;
            dbscooters.Version = request.Version;
            dbscooters.Tenant = request.Tenant;
            dbscooters.RentStart = request.RentStart;
            dbscooters.RentEnd = request.RentEnd;
            dbscooters.Price = request.Price;

            await _context.SaveChangesAsync();

            return Ok(await _context.Scooters.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Scooters>>> DeleteScooter(int id)
        {
            var dbscooters = await _context.Scooters.FindAsync(id);
            if (dbscooters == null)
                return BadRequest("Scooter not found.");

            _context.Scooters.Remove(dbscooters);
            await _context.SaveChangesAsync();
            return Ok(await _context.Scooters.ToListAsync());
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myhealthhub.api.Models;
using myhealthhub.api.Models.Entities;

namespace myhealthhub.api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PhysicianController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public PhysicianController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Physician>>> GetPhysicians()
        {
            return await _context.Physicians.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Physician>> GetPhysician(string id)
        {
            var physician = await _context.Physicians.FindAsync(Guid.Parse(id));

            if(physician == null)
            {
                return NotFound();
            }

            return physician;
        }

        [HttpGet("{email}")]
        [Route("byemail/{email}")]
        public async Task<ActionResult<Physician>> GetPhysicianByEmail(string email)
        {
            var physician = await _context.Physicians.Where(x => x.Email == email).FirstOrDefaultAsync();

            if(physician == null)
            {
                return NotFound();
            }

            return physician;
        }

        [HttpPost]
        public async Task<ActionResult<Physician>> PostPhysician(Physician physician)
        {
            _context.Physicians.Add(physician);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(PhysicianExists(physician.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetPhysician", new { id = physician.Id }, physician);
        }

        private bool PhysicianExists(string id)
        {
            return _context.Physicians.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
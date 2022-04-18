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
    public class VisitController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public VisitController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
        {
            return await _context.Visits.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Visit>> GetVisit(string id)
        {
            var visit = await _context.Visits.FindAsync(Guid.Parse(id));

            if(visit == null)
            {
                return NotFound();
            }

            return visit;
        }

        [HttpPost]
        public async Task<ActionResult<Visit>> PostVisit(Visit visit)
        {
            _context.Visits.Add(visit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(VisitExists(visit.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetVisit", new { id = visit.Id }, visit);
        }

        private bool VisitExists(string id)
        {
            return _context.Visits.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
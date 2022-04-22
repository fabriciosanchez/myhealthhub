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
    public class VisitPerStudy : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public VisitPerStudy(MyHealthHubContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<StudyPerVisit>> GetVisitPerStudy(string id)
        {
            var visitPerStudy = await _context.StudiesPerVisits.FindAsync(Guid.Parse(id));

            if(visitPerStudy == null)
            {
                return NotFound();
            }

            return visitPerStudy;
        }

        [HttpPost]
        public async Task<ActionResult<StudyPerVisit>> PostVisitPerStudy(StudyPerVisit visitPerStudy)
        {
            _context.StudiesPerVisits.Add(visitPerStudy);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(VisitPerStudyExists(visitPerStudy.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetVisitPerStudy", new { id = visitPerStudy.Id }, visitPerStudy);
        }

        private bool VisitPerStudyExists(string id)
        {
            return _context.StudiesPerVisits.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
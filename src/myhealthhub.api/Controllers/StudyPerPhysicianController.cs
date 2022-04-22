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
    public class StudyPerPhysicianController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public StudyPerPhysicianController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<StudyPerPhysician>> GetStudyPerPhysician(string id)
        {
            var studyByPhysician = await _context.StudiesPerPhysicians.FindAsync(Guid.Parse(id));

            if(studyByPhysician == null)
            {
                return NotFound();
            }

            return studyByPhysician;
        }

        [HttpPost]
        public async Task<ActionResult<StudyPerPhysician>> PostStudyPerPhysician(StudyPerPhysician studyPerPhysician)
        {
            _context.StudiesPerPhysicians.Add(studyPerPhysician);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(StudyPerPhysicianExists(studyPerPhysician.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetStudyPerPhysician", new { id = studyPerPhysician.Id }, studyPerPhysician);
        }

        private bool StudyPerPhysicianExists(string id)
        {
            return _context.StudiesPerPhysicians.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
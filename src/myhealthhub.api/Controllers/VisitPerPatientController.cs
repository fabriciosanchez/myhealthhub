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
    public class VisitPerPatientController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public VisitPerPatientController(MyHealthHubContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<VisitPerPatient>> GeVisitPerPatient(string id)
        {
            var visitPerPatient = await _context.VisitsPerPatients.FindAsync(Guid.Parse(id));

            if(visitPerPatient == null)
            {
                return NotFound();
            }

            return visitPerPatient;
        }

        [HttpPost]
        public async Task<ActionResult<StudyPerVisit>> PostVisitPerPatient(VisitPerPatient visitPerPatient)
        {
            _context.VisitsPerPatients.Add(visitPerPatient);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(VisitPerPatientExists(visitPerPatient.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GeVisitPerPatient", new { id = visitPerPatient.Id }, visitPerPatient);
        }

        private bool VisitPerPatientExists(string id)
        {
            return _context.VisitsPerPatients.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
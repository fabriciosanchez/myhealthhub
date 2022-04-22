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
    public class FormLabelPerVisitController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public FormLabelPerVisitController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<FormLabelPerVisit>> GetFormLabelPerVist(string id)
        {
            var formLabelPerVisit = await _context.FormLabelsPerVisits.FindAsync(Guid.Parse(id));

            if(formLabelPerVisit == null)
            {
                return NotFound();
            }

            return formLabelPerVisit;
        }

        [HttpPost]
        public async Task<ActionResult<FormLabelPerVisit>> PostFormLabelPerVisit(FormLabelPerVisit formLabelPerVisit)
        {
            _context.FormLabelsPerVisits.Add(formLabelPerVisit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(FormLabelPerVisitExists(formLabelPerVisit.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetFormLabelPerVist", new { id = formLabelPerVisit.Id }, formLabelPerVisit);
        }

        private bool FormLabelPerVisitExists(string id)
        {
            return _context.FormLabelsPerVisits.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
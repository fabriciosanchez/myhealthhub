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
    public class TrialFormController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public TrialFormController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrialForm>>> GetTrialForms()
        {
            return await _context.TrialForms.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TrialForm>> GetTrialForm(string id)
        {
            var trialForm = await _context.TrialForms.FindAsync(Guid.Parse(id));

            if(trialForm == null)
            {
                return NotFound();
            }

            return trialForm;
        }

        [HttpPost]
        public async Task<ActionResult<TrialForm>> PostTrialForm(TrialForm trialForm)
        {
            _context.TrialForms.Add(trialForm);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(TrialFormExists(trialForm.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetTrialForm", new { id = trialForm.Id }, trialForm);
        }

        private bool TrialFormExists(string id)
        {
            return _context.TrialForms.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
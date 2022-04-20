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
    public class TrialCompletionFormController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public TrialCompletionFormController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrialCompletionForm>>> GetTrialCompletionForms()
        {
            return await _context.TrialCompletionForms.ToListAsync();
        }


        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<TrialCompletionForm>> GetTrialCompletionForm(string id)
        {
            var trialCompletionForm = await _context.TrialCompletionForms.FindAsync(Guid.Parse(id));

            if(trialCompletionForm == null)
            {
                return NotFound();
            }

            return trialCompletionForm;
        }

        [HttpPost]
        public async Task<ActionResult<TrialCompletionForm>> PostTrialCompletionForm(TrialCompletionForm trialCompletionForm)
        {
            _context.TrialCompletionForms.Add(trialCompletionForm);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(TrialCompletionFormExists(trialCompletionForm.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetTrialCompletionForm", new { id = trialCompletionForm.Id }, trialCompletionForm);
        }

        private bool TrialCompletionFormExists(string id)
        {
            return _context.TrialCompletionForms.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
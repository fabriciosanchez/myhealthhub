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
    public class BaselineFormController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public BaselineFormController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaselineForm>>> GetBaselineForms()
        {
            return await _context.BaselineForms.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BaselineForm>> GetBaselineForm(string id)
        {
            var baselineForm = await _context.BaselineForms.FindAsync(Guid.Parse(id));

            if(baselineForm == null)
            {
                return NotFound();
            }

            return baselineForm;
        }

        [HttpPost]
        public async Task<ActionResult<BaselineForm>> PostBaselineForm(BaselineForm baselineForm)
        {
            _context.BaselineForms.Add(baselineForm);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(BaselineFormExists(baselineForm.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetBaselineForm", new { id = baselineForm.Id }, baselineForm);
        }

        private bool BaselineFormExists(string id)
        {
            return _context.BaselineForms.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
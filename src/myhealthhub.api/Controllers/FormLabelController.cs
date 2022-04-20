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
    public class FormLabelController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public FormLabelController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormLabel>>> GetFormLabels()
        {
            return await _context.FormsLabels.ToListAsync();
        }


        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<FormLabel>> GetFormLabel(string id)
        {
            var formLabel = await _context.FormsLabels.FindAsync(Guid.Parse(id));

            if(formLabel == null)
            {
                return NotFound();
            }

            return formLabel;
        }

        [HttpPost]
        public async Task<ActionResult<FormLabel>> PostFormLabel(FormLabel formLabel)
        {
            _context.FormsLabels.Add(formLabel);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(FormLabelExists(formLabel.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetFormLabel", new { id = formLabel.Id }, formLabel);
        }

        private bool FormLabelExists(string id)
        {
            return _context.FormsLabels.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
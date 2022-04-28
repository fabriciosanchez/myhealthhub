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
    public class StudyController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public StudyController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Study>>> GetStudy()
        {
            return await _context.Studies.ToListAsync();
        }


        [HttpGet("{id}")]
        [Route("byid/{id}")]
        public async Task<ActionResult<Study>> GetStudy(string id)
        {
            var study = await _context.Studies.FindAsync(Guid.Parse(id));

            if(study == null)
            {
                return NotFound();
            }

            return study;
        }

        [HttpGet("{physicianemail}")]
        [Route("byemail/{physicianemail}")]
        public async Task<ActionResult<IEnumerable<Study>>> GetStudiesPerPhysician(string physicianemail)
        {
            var studies = await (from s in _context.Studies
                                join spp in _context.StudiesPerPhysicians on s.Id equals spp.StudyId
                                join p in _context.Physicians on spp.PhysicianId equals p.Id
                                where p.Email == physicianemail
                                select s).ToListAsync();

            if(studies != null)
            {
                return studies;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Study>> PostStudy(Study study)
        {
            _context.Studies.Add(study);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(StudyExists(study.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetStudy", new { id = study.Id }, study);
        }

        private bool StudyExists(string id)
        {
            return _context.Studies.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
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
    public class PatientController : ControllerBase
    {
        private readonly MyHealthHubContext _context;

        public PatientController(MyHealthHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(string id)
        {
            var patient = await _context.Patients.FindAsync(Guid.Parse(id));

            if(patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpGet("{email}")]
        [Route("byemail/{email}")]
        public async Task<ActionResult<Patient>> GetPatientByEmail(string email)
        {
            var patient = await _context.Patients.Where(x => x.Email == email).FirstOrDefaultAsync();

            if(patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patients.Add(patient);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if(PatientExists(patient.Id.ToString()))
                {
                    return Conflict();
                }
                else
                {
                    return StatusCode(500);
                }
            }

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        private bool PatientExists(string id)
        {
            return _context.Patients.Any(e => e.Id == Guid.Parse(id));
        }
    }
}
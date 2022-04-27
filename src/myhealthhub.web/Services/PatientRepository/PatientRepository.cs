using myhealthhub.web.Models.Patient;
using myhealthhub.web.Services.Core;

namespace myhealthhub.web.Services.PatientRepository
{
    public class PatientRepository
    {
        private static IConfiguration _config;

        private readonly Http _http;

        private string _patientResource;

        public PatientRepository(IConfiguration config, Http http)
        {
            _config = config;
            _http = http;
            _patientResource = _config.GetSection("MyHealthHubApi").GetSection("PatientResource").Value;
        }

        public async Task<Patient> GetPatientByInternalIdAsync(string id)
        {
            try
            {
                return await _http.GetByInternalId<Patient>(_patientResource, id);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
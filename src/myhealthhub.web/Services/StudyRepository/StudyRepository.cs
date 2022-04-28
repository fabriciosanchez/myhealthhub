using myhealthhub.web.Models.Patient;
using myhealthhub.web.Models.Study;
using myhealthhub.web.Services.Core;

namespace myhealthhub.web.Services.PhysicianRepository
{
    public class StudyRepository
    {
        private static IConfiguration _config;

        private readonly Http _http;

        private string _studyResource;

        public StudyRepository(IConfiguration config, Http http)
        {
            _config = config;
            _http = http;
            _studyResource = _config.GetSection("MyHealthHubApi").GetSection("StudyResource").Value;
        }

        public async Task<List<Study>> GetStudiesForCurrentPhysician(string physicianEmail)
        {
            try
            {
                return await _http.GetByEmail<List<Study>>(_studyResource, physicianEmail);
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
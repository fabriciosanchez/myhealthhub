using myhealthhub.web.Models.Patient;
using myhealthhub.web.Models.Visit;
using myhealthhub.web.Services.Core;

namespace myhealthhub.web.Services.VisitRepository
{
    public class VisitRepository
    {
        private static IConfiguration _config;

        private readonly Http _http;

        private string _visitResource;

        public VisitRepository(IConfiguration config, Http http)
        {
            _config = config;
            _http = http;
            _visitResource = _config.GetSection("MyHealthHubApi").GetSection("VisitResource").Value;
        }

        public async Task<List<Visit>> GetVisitsPerSelectedStudy(Guid studyId)
        {
            try
            {
                return await _http.GetByStudyId<List<Visit>>(_visitResource, Convert.ToString(studyId));
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
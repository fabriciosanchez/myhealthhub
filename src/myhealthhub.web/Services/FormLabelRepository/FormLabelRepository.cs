using myhealthhub.web.Models.FormLabel;
using myhealthhub.web.Models.Patient;
using myhealthhub.web.Models.Visit;
using myhealthhub.web.Services.Core;

namespace myhealthhub.web.Services.FormLabelRepository
{
    public class FormLabelRepository
    {
        private static IConfiguration _config;

        private readonly Http _http;

        private string _formLabelResource;

        public FormLabelRepository(IConfiguration config, Http http)
        {
            _config = config;
            _http = http;
            _formLabelResource = _config.GetSection("MyHealthHubApi").GetSection("FormLabelResource").Value;
        }

        public async Task<List<FormLabel>> GetFormLabelsPerSelectedVisit(Guid visitId)
        {
            try
            {
                return await _http.GetByVisitId<List<FormLabel>>(_formLabelResource, Convert.ToString(visitId));
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
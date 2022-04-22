using Microsoft.AspNetCore.Mvc;

namespace myhealthhub.api.Models.DTOs
{
    public class UploadRequestHeaders
    {

        [FromHeader]
        public string PatientInternalId { get; set; }

        [FromHeader]
        public string PatientVisitId { get; set; }

        [FromHeader]
        public string PatientVisitName { get; set; }
    }
}
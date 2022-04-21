using Microsoft.AspNetCore.Mvc;

namespace myhealthhub.api.Models.DTOs
{
    public class UploadRequestHeaders
    {

        [FromHeader]
        public string PatientGivenName { get; set; }

        [FromHeader]
        public string PatientFamilyName { get; set; }

        [FromHeader]
        public string PatientVisit { get; set; }
    }
}
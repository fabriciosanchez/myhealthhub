using Microsoft.AspNetCore.Mvc;

namespace myhealthhub.api.Models.DTOs
{
    public class UploadModel
    {
        [FromForm]
        public List<IFormFile> Files { get; set; }
    }
}
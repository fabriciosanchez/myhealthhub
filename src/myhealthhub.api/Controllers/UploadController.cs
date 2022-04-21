using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myhealthhub.api.Interfaces;
using myhealthhub.api.Models.DTOs;

namespace myhealthhub.api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IFileManager _fileManager;

        public UploadController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        [Route("upload")]
        [HttpPost]
        public async Task<ActionResult> Upload([FromForm]UploadModel uploadModel, [FromHeader]UploadRequestHeaders headers)
        {
            if(uploadModel.Files?.Any() ?? false)
            {
                await _fileManager.Upload(uploadModel, headers);
            }

            return Ok();
        }
    }
}
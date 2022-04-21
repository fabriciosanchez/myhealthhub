using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using myhealthhub.api.Interfaces;
using myhealthhub.api.Models;
using myhealthhub.api.Models.DTOs;
using myhealthhub.api.Models.Entities;

namespace myhealthhub.api.Services
{
    public class FileManager : IFileManager
    {
        private readonly BlobServiceClient _blobServiceClient;

        private readonly IHelper _helper;
        
        private readonly MyHealthHubContext _context;

        private readonly IDatabaseManager _databaseManager;
        public FileManager(BlobServiceClient blobServiceClient, IHelper helper, MyHealthHubContext context, IDatabaseManager databaseManager)
        {
            _blobServiceClient = blobServiceClient;
            _helper = helper;
            _context = context;
            _databaseManager = databaseManager;
        }

        public async Task Upload(UploadModel uploadModel, UploadRequestHeaders headers)
        {
            Upload upload = new Upload(); 

            foreach (var file in uploadModel.Files)
            {
                string fileName = $"{_helper.GenerateDateAsString()}_{_helper.GenerateGuidAsString()}_{headers.PatientGivenName}-{headers.PatientFamilyName}";
                var extension = Path.GetExtension(file.FileName);
                var fileNameAndExtension = $"{fileName}{extension}";
                string fileNameAndExtensioNoSpace = fileNameAndExtension.Replace(" ","-");
                string fileNameAndExtensionNoDiacritics = _helper.RemoveDiacritics(fileNameAndExtensioNoSpace);

                var container = _blobServiceClient.GetBlobContainerClient("files");

                var client = container.GetBlobClient(fileNameAndExtensionNoDiacritics);

                await client.UploadAsync(file.OpenReadStream());

                // Populates upload object
                upload.Id = Guid.NewGuid();
                upload.FileName = fileNameAndExtensionNoDiacritics;
                upload.VisitId = Guid.Parse(headers.PatientVisit);

                await _databaseManager.Create<Upload>(upload);
            }
        }
    }
}
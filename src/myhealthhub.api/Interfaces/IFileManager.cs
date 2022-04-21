using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myhealthhub.api.Models.DTOs;

namespace myhealthhub.api.Interfaces
{
    public interface IFileManager
    {
        Task Upload(UploadModel uploadModel, UploadRequestHeaders headers);
    }
}
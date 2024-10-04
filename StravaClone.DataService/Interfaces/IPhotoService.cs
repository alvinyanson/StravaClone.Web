using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace StravaClone.DataService.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);

    }
}

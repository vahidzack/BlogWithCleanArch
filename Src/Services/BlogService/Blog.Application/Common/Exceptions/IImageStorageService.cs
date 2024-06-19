using Microsoft.AspNetCore.Http;

namespace Blog.Application.Common.Exceptions
{
    public interface IImageStorageService
    {
        Task<string> StoreImageAsync(IFormFile imageFile, string fileName);
    }
}

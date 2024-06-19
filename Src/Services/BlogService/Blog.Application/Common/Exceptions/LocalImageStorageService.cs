using Microsoft.AspNetCore.Http;

namespace Blog.Application.Common.Exceptions
{
    public class LocalImageStorageService : IImageStorageService
    {
        private readonly string _imageBasePath = "wwwroot/images"; // Example path

        public async Task<string> StoreImageAsync(IFormFile imageFile, string fileName)
        {
            var filePath = Path.Combine(_imageBasePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return filePath; 
        }
    }
}

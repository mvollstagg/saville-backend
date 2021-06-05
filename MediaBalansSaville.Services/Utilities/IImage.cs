using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services.Utilities
{
    public interface IImage
    {
        public Task<string> UploadAsync(IFormFile file, string outerFolderName, string innerFolderName);
        public Task<string> UploadForProductAsync(IFormFile file, int index, string slugUrl, bool Is3D, string outerFolderName, string innerFolderName);
        public void Delete(string outerFolderName, string innerFolderName, string fileName);
        public void DeleteForProduct(string outerFolderName, string innerFolderName, string slugUrl, string fileName);
        public bool IsImageValid(IFormFile file);
    }
}

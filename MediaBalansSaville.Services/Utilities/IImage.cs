using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services.Utilities
{
    public interface IImage
    {
        public Task<string> UploadAsync(IFormFile file, string outerFolderName, string innerFolderName);
        public void Delete(string outerFolderName, string innerFolderName, string fileName);
        public bool IsImageValid(IFormFile file);
    }
}

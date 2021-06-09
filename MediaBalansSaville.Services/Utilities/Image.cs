using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services.Utilities
{
    public class Image : IImage
    {
        public async Task<string> UploadAsync(IFormFile file, string outerFolderName, string innerFolderName)
        {
            string folderPath = Path.Combine("wwwroot", outerFolderName, innerFolderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileExtension = file.ContentType.Substring(file.ContentType.IndexOf("/") + 1,
                                    file.ContentType.Length - file.ContentType.IndexOf("/") - 1);
                                    
            if(fileExtension == "svg+xml")
                fileExtension = "svg";
            string fileName = Guid.NewGuid().ToString() + "_" + "Saville" +  "." + fileExtension;
            string filePath = Path.Combine(folderPath, fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);            
            return fileName;
        }
        public async Task<string> UploadForProductAsync(IFormFile file, int index, string slugUrl, bool Is3D, string outerFolderName, string innerFolderName)
        {
            string folderPath = Path.Combine("wwwroot", outerFolderName, innerFolderName, slugUrl);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileExtension = file.ContentType.Substring(file.ContentType.IndexOf("/") + 1,
                                    file.ContentType.Length - file.ContentType.IndexOf("/") - 1);
                                    
            string fileName;
            if(Is3D)
                fileName = "img" +  (index) +  ".jpg";
            else
                fileName = Guid.NewGuid().ToString() + "_" + "Saville" +  "." + fileExtension;
            string filePath = Path.Combine(folderPath, fileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                await file.CopyToAsync(fileStream);            
            return fileName;
        }
        public void DeleteForProduct(string outerFolderName, string innerFolderName, string slugUrl, string fileName)
        {
            string folderPath = Path.Combine("wwwroot", outerFolderName, innerFolderName, slugUrl);
            string filePath = Path.Combine(folderPath, fileName);
            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
        }
        public void Delete(string outerFolderName, string innerFolderName, string fileName)
        {
            string folderPath = Path.Combine("wwwroot", outerFolderName, innerFolderName);
            string filePath = Path.Combine(folderPath, fileName);
            if (System.IO.File.Exists(filePath)) System.IO.File.Delete(filePath);
        }
        public bool IsImageValid(IFormFile file)
        {
            if (file.Length <= 3 * 1024 * 1024 && (file.ContentType == "image/jpg" ||
                                                   file.ContentType == "image/png" ||
                                                   file.ContentType == "image/svg+xml" ||
                                                   file.ContentType == "image/jpeg"))
                return true;
            else
                return false;
        }
    }
}

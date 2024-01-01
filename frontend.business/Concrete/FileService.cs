using frontend.business.Abstrations;
using frontend.data.Abstract;
using Microsoft.AspNetCore.Http;

namespace frontend.business.Concrete
{
    public class FileService : IFileService
    {

        readonly private IFilesReadRepository _filesReadRepository;
        readonly private IFilesWriteRepository _filesWriteRepository;
        

        public FileService(IFilesReadRepository  filesReadRepository , IFilesWriteRepository filesWriteRepository)
        {
            _filesReadRepository= filesReadRepository;
            _filesWriteRepository= filesWriteRepository;
        }

        public bool CheckSize(IFormFile file, int maxSize)
        {
            if (file.Length / 1024 < maxSize)
            {
                return false;
            }
            return true;    
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public bool IsImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }

         
            if (!file.ContentType.StartsWith("image/"))
            {
                return false;
            }

       
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" }; 
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return false;
            }

            return true;
        }


        public async  Task<string> UploadAsync(IFormFile file)
        {
            var filename = $"{Guid.NewGuid()}_{file.FileName}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/img", filename);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}

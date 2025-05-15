using Microsoft.AspNetCore.Hosting;

namespace Events.Application.Services
{


    public class FileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public async Task<string> UploadImageAsync(IFormFile file, string targetFolder)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid image file");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var folderPath = Path.Combine("images", targetFolder);
            var filePath = Path.Combine(folderPath, fileName);
            var fullPath = Path.Combine(_environment.WebRootPath, filePath);

            // Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath.Replace("\\", "/");
            //--------------------------

            //string wwwrootPath = _webHostEnvironment.WebRootPath;
            //string fileName = Guid.NewGuid().ToString();
            //string extension = Path.GetExtension(file.FileName);
            //string fullPath = wwwrootPath + @"\Images\products\" + fileName + extension;
            //using (var fileStream = new FileStream(fullPath, FileMode.Create))
            //{
            //    file.CopyTo(fileStream);
            //}
            //Product product = new()
            //{
            //    Name = productVm.Name,
            //    Id = productVm.Id,
            //    Price = productVm.Price,
            //    Description = productVm.Description,
            //    ImgPath = $"Images/Products/{fileName}{extension}",
            //    CategoryId = productVm.CategoryId,
            //    Category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == productVm.CategoryId)
            //};

        }

        public async Task<string?> UpdateImageAsync(IFormFile newFile ,string oldImagePath )
        {
            if (newFile != null)
            {
                string wwwrootPath = _environment.WebRootPath;
                string oldFilePath = wwwrootPath + "\\images\\events\\" + Path.GetFileName(oldImagePath);   

                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);

                }

                string newFileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(newFile.FileName);
                string fullPath = wwwrootPath + @"\images\events\" + newFileName + extension;
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await newFile.CopyToAsync(fileStream);
                }

                 var newImagePath = $"Images/events/{newFileName}{extension}";  
                return newImagePath;
            }
            return null;
        }

    }

}

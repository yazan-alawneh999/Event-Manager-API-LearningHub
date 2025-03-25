using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LearningHub.Infra.Util;

public class UtilService
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public UtilService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    
    public async Task<string?> SaveImageAsync(IFormFile imageFile)
    {
        if (imageFile == null) return null;

        // Local location of images on the disk
        string uploadsPath = Path.Combine(_webHostEnvironment.ContentRootPath, "images");
        Directory.CreateDirectory(uploadsPath); // Create directory if it doesn't exist

        // Generate unique image name
        string uniqueImageName = $"{Guid.NewGuid()}_{imageFile.FileName}";
        string imagePath = Path.Combine(uploadsPath, uniqueImageName);

        // Save the file to the disk
        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }

        // Return the relative path for database storage
        return imagePath;
    }
}
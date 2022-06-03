using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Utilities.Images;

public static class ImageUploadHelper
{
    public static void CheckDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public static async Task<string> UploadImage(IFormFile img, string path)
    {
        CheckDirectory(path);

        var fileName = Guid.NewGuid().ToString() + ".jpg";

        var filePath = Path.Combine(path, fileName);
        var image = await ImageHelper.Resize(img, 1024);
        ImageHelper.SaveImage(image, filePath);

        return fileName;
    }

    public static async Task<string> UploadImage(IFormFile img, string path, int width, int height)
    {
        CheckDirectory(path);

        var fileName = Guid.NewGuid().ToString() + ".jpg";

        var filePath = Path.Combine(path, fileName);
        var image = await ImageHelper.Crop(img, width, height);
        ImageHelper.SaveImage(image, filePath);

        return fileName;
    }

    public static async void UploadImage(IFormFile img, string path, string fileName, int width, int height)
    {
        CheckDirectory(path);

        var filePath = Path.Combine(path, fileName);
        var image = await ImageHelper.Crop(img, width, height);
        ImageHelper.SaveImage(image, filePath);
    }

    public static async void UploadImage(IFormFile img, string path, string fileName)
    {
        CheckDirectory(path);

        var filePath = Path.Combine(path, fileName);
        var image = await ImageHelper.Resize(img, 1024);
        ImageHelper.SaveImage(image, filePath);
    }

    public static async Task<string> UploadResponsiveImages(IFormFile img, string path, int width, int height)
    {
        var smallImgPath = Path.Combine(path, "small");
        var mediumImgPath = Path.Combine(path, "medium");

        var fileName = Guid.NewGuid().ToString() + ".jpg";

        var smallImg = Path.Combine(smallImgPath, fileName);
        var mediumImg = Path.Combine(mediumImgPath, fileName);

        CheckDirectory(smallImgPath);
        CheckDirectory(mediumImgPath);

        var croppedImg = await ImageHelper.Crop(img, width, height);
        var resizedImg = await ImageHelper.Resize(croppedImg, 350);
        ImageHelper.SaveImage(croppedImg, mediumImg);
        ImageHelper.SaveImage(resizedImg, smallImg);

        return fileName;
    }
}
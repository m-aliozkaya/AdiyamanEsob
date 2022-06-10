using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Core.Utilities.Files;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;

namespace Core.Utilities.Images;

public static class ImageUploadHelper
{
    private const string UploadPath = "wwwroot/upload/";

    private static void CheckDirectory(string path)
    {
        var fileInfo = new FileInfo(path);

        if (fileInfo.Directory is { Exists: false })
        {
            fileInfo.Directory.Create();
        }
    }

    public static async Task<IDataResult<string>> UploadImage(IFormFile img, string path)
    {
        if (img == null || img.Length == 0)  
            return new ErrorDataResult<string>("Dosya seçilmedi");
        
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
        var filePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, fileName);
        
        CheckDirectory(filePath);
        
        var image = await ImageHelper.Resize(img, 1024);
        ImageHelper.SaveImage(image, filePath);

        return new SuccessDataResult<string>(data:fileName);
    }

    public static async Task<IDataResult<string>> UploadImage(IFormFile img, string path, int width, int height)
    {
        if (img == null || img.Length == 0)  
            return new ErrorDataResult<string>("Dosya seçilmedi");
        
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
        var filePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, fileName);
        
        CheckDirectory(filePath);
        
        var image = await ImageHelper.Crop(img, width, height);
        ImageHelper.SaveImage(image, filePath);

        return new SuccessDataResult<string>(data:fileName);
    }

    public static async Task<IDataResult<string>> UploadResponsiveImages(IFormFile img, string path)
    {
        if (img == null || img.Length == 0)  
            return new ErrorDataResult<string>("Dosya seçilmedi");
        
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
        
        var mediumFilePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, "medium", fileName);
        
        var smallFilePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, "small", fileName);
        
        CheckDirectory(mediumFilePath);
        CheckDirectory(smallFilePath);
        
        var mediumImage = await ImageHelper.Resize(img, 1024);
        var smallImage = await ImageHelper.Resize(img, 350);
        ImageHelper.SaveImage(mediumImage, mediumFilePath);
        ImageHelper.SaveImage(smallImage, smallFilePath);
        
        return new SuccessDataResult<string>(data:fileName);
    }
    public static async Task<IDataResult<string>> UploadResponsiveImages(IFormFile img, string path, int width, int height)
    {
        if (img == null || img.Length == 0)  
            return new ErrorDataResult<string>("Dosya seçilmedi");
        
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
        
        var mediumFilePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, fileName);
        
        var smallFilePath = Path.Combine(  
            Directory.GetCurrentDirectory(), UploadPath,
            path, fileName);
        
        CheckDirectory(mediumFilePath);
        CheckDirectory(smallFilePath);

        var croppedImg = await ImageHelper.Crop(img, width, height);
        var resizedImg = await ImageHelper.Resize(croppedImg, 350);
        ImageHelper.SaveImage(croppedImg, mediumFilePath);
        ImageHelper.SaveImage(resizedImg, smallFilePath);
        
        return new SuccessDataResult<string>(data:fileName);
    }
    
    public static async Task<IDataResult<string>> UpdateImageAsync(IFormFile file, string path, string oldPath)
    {
        if (file == null || file.Length == 0)  
            return new ErrorDataResult<string>("Dosya seçilmedi");
        
        FileHelper.DeleteFile(path, oldPath);
        return await UploadImage(file, path);
    }
    
    public static async Task<IDataResult<string>> UpdateResponsiveImageAsync(IFormFile file, string path, string oldPath)
    {
        if (file == null || file.Length == 0)  
            return new ErrorDataResult<string>("Dosya seçilmedi");
        
        var mediumPath = Path.Combine(path, "medium");
        FileHelper.DeleteFile(mediumPath, oldPath);
        
        var smallPath = Path.Combine(path, "small");
        FileHelper.DeleteFile(smallPath, oldPath);

        return await UploadResponsiveImages(file, path);
    }
}